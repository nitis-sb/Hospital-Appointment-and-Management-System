using System.Numerics;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Appointment_and_Management_System.Data
{
    public static class DbSeeder
    {
        public static async Task SeedDoctorsAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!await roleManager.RoleExistsAsync("Doctor"))
            {
                await roleManager.CreateAsync(new IdentityRole("Doctor"));
            }

            var doctors = new[]
            {
        new { DoctorId = 10001, Email = "10001@example.com", Name = "Dr. Praveen Ram", Password = "Doctor@10001" },
        new { DoctorId = 10002, Email = "10002@example.com", Name = "Dr. Senthil", Password = "Doctor@10002" },
        new { DoctorId = 10003, Email = "10003@example.com", Name = "Dr. Prachodan", Password = "Doctor@10003" },
        new { DoctorId = 10004, Email = "10004@example.com", Name = "Dr. Nitis", Password = "Doctor@10004" },
        new { DoctorId = 10005, Email = "10005@example.com", Name = "Dr. Vaidik", Password = "Doctor@10005" },
        new { DoctorId = 10006, Email = "10006@example.com", Name = "Dr. Vineeth", Password = "Doctor@10006" },
    };

            dbContext.Database.OpenConnection();
            try
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Doctors ON");

                foreach (var doc in doctors)
                {
                    if (await userManager.FindByEmailAsync(doc.Email) == null)
                    {
                        var user = new IdentityUser { UserName = doc.Email, Email = doc.Email };
                        var result = await userManager.CreateAsync(user, doc.Password);

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "Doctor");

                            var doctor = new Doctor
                            {
                                DoctorID = doc.DoctorId,
                                Name = doc.Name,
                                Email = doc.Email,
                                UserId = user.Id
                            };

                            dbContext.Doctors.Add(doctor);
                        }
                    }
                }

                await dbContext.SaveChangesAsync();
            }
            finally
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Doctors OFF");
                dbContext.Database.CloseConnection();
            }
        }
    }
}