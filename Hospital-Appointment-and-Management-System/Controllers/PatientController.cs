using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

        [HttpPost("register")]
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _patientService.LoginAsync(loginModel.Email, loginModel.Password);
                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPatient([FromBody] PatientProfile patientProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPatient = await _patientService.AddPatientAsync(patientProfile);
            return CreatedAtAction(nameof(GetPatientProfile), new { patientId = createdPatient.PatientID }, createdPatient);
        }

        [HttpGet("{patientId}")]
        [Authorize]
        public async Task<IActionResult> GetPatientProfile(int patientId)
        {
            try
            {
                var patientProfile = await _patientService.GetPatientProfileAsync(patientId);
                return Ok(patientProfile);
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{patientId}")]
        [Authorize]
        public async Task<IActionResult> UpdatePatientProfile(int patientId, [FromBody] PatientProfile patientProfile)
        {
            if (patientId != patientProfile.PatientID)
            {
                return BadRequest("Patient ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedPatient = await _patientService.UpdatePatientProfileAsync(patientId, patientProfile);
                return Ok(updatedPatient);
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpDelete("{patientId}")]
        [Authorize(Roles ="USER")]
        public async Task<IActionResult> DeletePatientProfile(int patientId)
        {
            try
            {
                await _patientService.DeletePatientProfileAsync(patientId);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }

}
