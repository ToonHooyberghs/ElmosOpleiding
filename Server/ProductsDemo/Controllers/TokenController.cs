using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ProductsDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateToken([FromBody] BePLoginModel login)
        {
            IActionResult response = Unauthorized();

            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new {token = tokenString});
            }

            return response;
            
        }

        private UserModel Authenticate(BePLoginModel model)
        {
            UserModel user = null;

            if (model.Username == "toon" && model.Password == "geeninspiratie")
            {
                user = new UserModel()
                {
                    Name = "Toon Hooyberghs",
                    Email = "Toon@email.com"
                };
            }


            return user;
        }


        private string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:ServerSecret"]));
            var creds = new  SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Issuer"], expires: DateTime.Now.AddHours(10), signingCredentials:creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class BePLoginModel
    {
        public string Password { get; set; }
        public string Username { get; set; }

    }

    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

}