using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using Hospital_Appointment_and_Management_System.DTO;
using Hospital_Appointment_and_Management_System.Interface;
using Hospital_Appointment_and_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hospital_Appointment_and_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public PatientController(IPatientService patientService, IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterPatient([FromBody] PatientRegistrationModel patientRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var patientProfile = await _patientService.RegisterPatientAsync(patientRegistration);
                var user = await _userManager.FindByEmailAsync(patientRegistration.Email);
                if (user != null)
                {
                    await _userManager.AddToRoleAsync(user, "USER");
                }
                return Ok(patientProfile);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _patientService.LoginAsync(loginModel.Email, loginModel.Password);
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();
                var token = GenerateJwtToken(user, role);
                return Ok(new { Token = token });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [Route("profile/{userId}")]
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetPatientProfile(string userId)
        {
            try
            {
                var patientProfile = await _patientService.GetPatientProfileAsync(userId);

                if (patientProfile == null)
                {
                    return NotFound(new { message = "Patient profile not found." });
                }

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };

                var jsonString = JsonSerializer.Serialize(patientProfile, options);
                return Ok(jsonString);
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Route("patients/user/{username}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPatientIdByUsername(string username)
        {
            try
            {
                var patientId = await _patientService.GetPatientIdByUsernameAsync(username);
                return Ok(patientId);
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Route("{patientId}")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdatePatientProfile(string userId, [FromBody] PatientProfile patientProfile)
        {
            if (userId != patientProfile.UserId)
            {
                return BadRequest("Patient ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedPatient = await _patientService.UpdatePatientProfileAsync(userId, patientProfile);
                return Ok(updatedPatient);
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }





        private string GenerateJwtToken(IdentityUser user, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var claims = new List<Claim>
 {
 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
 new Claim(ClaimTypes.Name, user.UserName),
 new Claim(ClaimTypes.Role, role)
 };
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }

}
