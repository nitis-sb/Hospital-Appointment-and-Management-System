using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System;
using Hospital_Appointment_and_Management_System.Data;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Repositories;
using Hospital_Appointment_and_Management_System.Services;
using Microsoft.Extensions.Options;
using Hospital_Appointment_and_Management_System.Interfaces;
using Hospital_Appointment_and_Management_System.Repository;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Hospital Management and Appointment System",
        Version = "v1"
    });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Add Identity services
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Userreg")
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuer = true,
       ValidateAudience = true,
       ValidateLifetime = true,
       ValidateIssuerSigningKey = true,
       ValidIssuer = builder.Configuration["Jwt:Issuer"],
       ValidAudience = builder.Configuration["Jwt:Audience"],
       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
   });


builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Configure Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    ;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

async Task CreateRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roleNames = { "USER", "ADMIN" };
    IdentityResult roleResult;

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Create a hardcoded admin user
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var adminUser = new IdentityUser
    {
        UserName = "admin@admin.com",
        Email = "admin@admin.com"
    };

    string adminPassword = "Admin@1234567890";
    var admin_user = await userManager.FindByEmailAsync("admin@admin.com");

    if (admin_user == null)
    {
        var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
        if (createAdminUser.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "ADMIN");
        }
    }
    var doctorList = new List<IdentityUser>
{
    new IdentityUser { UserName = "10001@example.com", Email = "10001@example.com", EmailConfirmed = true },
    new IdentityUser { UserName = "10002@example.com", Email = "10002@example.com", EmailConfirmed = true },
    new IdentityUser { UserName = "10003@example.com", Email = "10003@example.com", EmailConfirmed = true },
    new IdentityUser { UserName = "10004@example.com", Email = "10004@example.com", EmailConfirmed = true },
    new IdentityUser { UserName = "10005@example.com", Email = "10005@example.com", EmailConfirmed = true },
    new IdentityUser { UserName = "10006@example.com", Email = "10006@example.com", EmailConfirmed = true }
};

    foreach (var doctorUser in doctorList)
    {
        var existingUser = await userManager.FindByEmailAsync(doctorUser.Email);
        if (existingUser != null)
        {
            // Assign the role of admin to the existing user
            var addToRoleResult = await userManager.AddToRoleAsync(existingUser, "ADMIN");
            if (addToRoleResult.Succeeded)
            {
                Console.WriteLine($"User {doctorUser.Email} added to Admin role successfully!");
            }
            else
            {
                foreach (var error in addToRoleResult.Errors)
                {
                    Console.WriteLine($"Error adding to role: {error.Description}");
                }
            }
        }
        else
        {
            Console.WriteLine($"User {doctorUser.Email} does not exist.");
        }
    }

}

var serviceProvider = builder.Services.BuildServiceProvider();
await CreateRoles(serviceProvider);

// Register services and repositories
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
builder.Services.AddScoped<DoctorScheduleService>();
builder.Services.AddScoped<IServiceAppointment, AppointmentService>();
builder.Services.AddScoped<IRepositoryAppointment, AppointmentRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
builder.Services.AddScoped<IDoctorSchedulingService, DoctorScheduleService>();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();