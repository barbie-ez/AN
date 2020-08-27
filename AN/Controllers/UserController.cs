using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AN.Core.Domain;
using AN.DTO.Get;
using AN.DTO.Post;
using AN.DTO.Response;
using AN.Helpers;
using AN.Helpers.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AN.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppSettings _appSettings;
        public static IWebHostEnvironment _environment;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager,
            IWebHostEnvironment environment,IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _environment = environment;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [Produces("application/json")]
        public async Task<ActionResult> Login([FromBody] LoginDTO user)
        {
            if(string.IsNullOrEmpty(user.Username)|| string.IsNullOrEmpty(user.Username))
            {
                return BadRequest("Incorrect parameters passed");
            }
        
            var userProfile = await _userManager.FindByEmailAsync(user.Username);

            if (userProfile == null)
            {
                return Unauthorized("Incorrect Username or Password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(userProfile, user.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Incorrect Username or Password");
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userProfile.Id.ToString()),
                }),

                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new ResponseDTO<UserDTO>
            {
                Code = ResponseCodes.Success,
                responseMessage = "Login Success",
                returnObject = new UserDTO()
                {
                    Token = tokenHandler.WriteToken(token),
                    Email = userProfile.Email,
                    FirstName = userProfile.Firstname,
                    LastName = userProfile.Lastname,
                    Id = userProfile.Id,
                    ExpiresOn = tokenDescriptor.Expires.ToString(),
                }
            });

        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO user)
        {

            if (user == null)
            {
                return BadRequest();
            }

            var newUser = new User
            {
               Email=user.Email,
               Firstname=user.FirstName,
               Lastname=user.LastName,
               DateOfBirth=user.DateOfBirth,
               ProfilePic= UploadFile(user.ProfilePic),
               
            };

            
            return Ok();

        }

        private string UploadFile(IFormFile file)
        {
            string filename = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return filename;
        }

    }

}


    

