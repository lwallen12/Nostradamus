using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Nostradamus.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Nostradamus.DTOs;
using Nostradamus.Mail;

namespace Nostradamus.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<Noster> _signInManager;
        private readonly UserManager<Noster> _userManager;
        private readonly IUnitofWork _unitofWork;

        public AccountsController(
            UserManager<Noster> userManager,
            SignInManager<Noster> signInManager,
            IUnitofWork unitofWork
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitofWork = unitofWork;
        }

        [HttpGet]
        public string GetString()
        {
            return "Yes the url now works"; //http://localhost:57096/api/accounts
        }

        [HttpPost("Login")]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            //TODO: Call to verify your account

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);

                return await GenerateJwtToken(model.Email, appUser);
            }

            throw new ApplicationException("Problem with Username or password. Resetting may not be set up yet! :(");
        }

        

        [HttpPost("refresh")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<object> Refresh()
        {
            //var handler = new JwtSecurityTokenHandler();
            //var accessToken = Request.Headers["Authorization"];
            //var tokenDecode = handler.ReadToken(accessToken) as JwtSecurityToken;

            var token = await HttpContext.GetTokenAsync("access_token");

            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

            var subject = tokenDecode.Subject;

            var user = _userManager.Users.SingleOrDefault(r => r.Email == subject);

            if (user == null)
            {
                throw new ApplicationException("User does not exist");
            }

            var newAccessToken = GenerateJwtToken(subject, user);

            return  await newAccessToken;

            //This is if the token is going to come from the req body
        }


        [HttpPost("Refresh/header")]
        public async Task<string> RefreshHeader()
        {
            //token here will be null if token is invalid
            var token = await HttpContext.GetTokenAsync("access_token");

            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

            var subject = tokenDecode.Subject;

            return subject;

            //var accessToken = Request.Headers["Authorization"];

            //return accessToken;

            //This is if the token is going to come from the req header... for some reason only works when a valid access token
        }

        [HttpPost("reset")]
        public async Task Reset([FromBody] UserSet userSet)
        {

            
                Noster noster = _unitofWork.Noster.GetForToken(userSet.Username);
                

            if (noster != null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(noster);
                MailHelper.sendReset("a.allenwill@gmail.com", userSet.Username, resetToken);
            }
                //return resetToken;
           


            //TODO: probably send an email, text of the reset token to the user
        }


        [HttpPost("change")]
        public async Task<IdentityResult> Change([FromBody] UserSet userSet)
        {
            Noster noster = _unitofWork.Noster.GetForToken(userSet.Username);

            return await _userManager.ResetPasswordAsync(noster, userSet.ResetToken, userSet.NewPassword);

        }

        [HttpPost("register")]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            var user = new Noster
            {
                UserName = model.Email,
                Email = model.Email,
                CreationDate = DateTime.Now,
                DisplayName = model.DisplayName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                MailHelper.sendSignUpAlert(model.Email);
                return await GenerateJwtToken(model.Email, user);
            }

            else
            {
                throw new ApplicationException("UNKNOWN_ERROR");
            }

            
        }

        private async Task<object> GenerateJwtToken(string email, Noster user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SOME_RANDOM_KEY_DO_NOT_SHARE"));
            var creds =  new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expires = DateTime.Now.AddDays(Convert.ToDouble(30));
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(60));

            var token = new JwtSecurityToken(
                "https://localhost:57096",
                "https://localhost:57096",
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Protected")]
        public async Task<IEnumerable<NosterDto>> Protected()
        {

            return await _unitofWork.Noster.FindAllWithIncludes();
                
        }


        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public class TokenPackageDTO
        {
            public string AccessToken { get; set; }
            public DateTime? RefreshExpiration { get; set; }
            public string RefreshToken { get; set; }
        }


        public class LoginDto
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

        }

        public class RegisterDto
        {
            [Required]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
            public string Password { get; set; }
            public string DisplayName { get; set; }
            public DateTime CreationDate { get; set; }
        }

        public class UserSet
        {
            public string Username { get; set; }
            public string ResetToken { get; set; }
            public string NewPassword { get; set; }
        }
    }
}
