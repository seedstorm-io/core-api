using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SeedStorm.Core.Dtos;
using SeedStorm.Core.Entities;

namespace seedstorm_core.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IConfiguration configuration, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ILogger<AuthenticationController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Authenticate the specified user with email and password
        /// </summary>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> AuthenticateAsync([FromBody]AuthDto AuthDto)
        {
            var user = await _userManager.FindByEmailAsync(AuthDto.Email);
            if (user != null)
            {
                var response = await _signInManager.CheckPasswordSignInAsync(user, AuthDto.Password, false);
                if (response.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                            new Claim(ClaimTypes.Email, user.Email),
                        }),
                        IssuedAt = DateTime.Now,
                        NotBefore = DateTime.Now,
                        Expires = DateTime.MaxValue,
                        Audience = _configuration["Jwt:Issuer"],
                        Issuer = _configuration["Jwt:Issuer"],
                        SigningCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256),
                        //EncryptingCredentials = new EncryptingCredentials(tokenKey, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    _logger.LogInformation($"User {user.Email} sucessfully loggd");
                    
                    return Ok(new
                    {
                        user.Email,
                        user.AccessFailedCount,
                        Token = tokenString
                    });
                }
                else if (response.IsNotAllowed)
                {
                    return Unauthorized(new { message = "Username or password is incorrect" });
                }
                else if (response.RequiresTwoFactor)
                {
                    return BadRequest("Two factor is required");
                }
                else if (response.IsLockedOut)
                {
                    return BadRequest("is locked");
                }
            }
            return BadRequest(new { message = "This user does not exist" });
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody]AuthDto AuthDto)
        {
            var user = new ApplicationUser()
            {
                Email = AuthDto.Email,
                UserName = AuthDto.Email,
                IsAllowed = true
            };
            var response = await _userManager.CreateAsync(user, AuthDto.Password);
            if(response.Succeeded)
            {
                _logger.LogInformation($"New user registred: {user.Email}");
                return Ok();
            }
            return BadRequest(new { errors = response.Errors });
        }

        /// <summary>
        /// Get the current logged-in user
        /// </summary>
        [HttpGet("get")]
        public async Task<ActionResult<ApplicationUser>> GetAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await GetAsync(userId);
        }

        /// <summary>
        /// Get a specific user by this ID
        /// </summary>
        [Authorize(Roles = "Administrator")]
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
        
        /// <summary>
        /// Drop an user
        /// </summary>
        [Authorize(Roles = "Administrator")]
        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteAsync([FromBody]AuthDto AuthDto)
        {
            var user = await _userManager.FindByEmailAsync(AuthDto.Email);
            var response = await _userManager.DeleteAsync(user);
            if (response.Succeeded)
            {
                return Ok();
            }
            return BadRequest(new { errors = response.Errors });
        }

    }
}