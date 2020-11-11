using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Plans.DomainModel.Users;
using Plans.Foundation.AuthOptions;
using Plans.Repositories.DbContexts;

namespace Plans.Controllers
{
    public class AccountController : Controller
    {
        private readonly PlansDbContext _plansDbContext;


        public AccountController(PlansDbContext plansDbContext)
        {
            _plansDbContext = plansDbContext;
        }

        [HttpGet]
        public IActionResult Token(string login, string password)
        {
            //TODO: INCRIPTING FUNK
            var passHash = login;
            var user = _plansDbContext.Users.FirstOrDefault(u => u.Login == login && u.PasswordHash == u.PasswordHash);
            
            if(user == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            var now = DateTime.UtcNow;

            //TODO: ADD Factory to JwtSecurityToken
            var jwt = new JwtSecurityToken(
                issuer: JwtAuthOptions.ISSUER,
                audience: JwtAuthOptions.AUDIENCE,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(JwtAuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(
                    JwtAuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Content(encodedJwt);
        }

        [HttpPost]
        public IActionResult Register(ClientUser user) 
        {
            if(user == null || user.Login == null || user.Password == null)
            {
                return BadRequest();
            }

            if(user.Login == "" || user.Password == "")
            {
                return BadRequest(new { errorText = "Login and password must not be empty" });
            }

            if(_plansDbContext.Users.FirstOrDefault(u => u.Login == user.Login) != null)
            {
                return Forbid("User with such login already exists");
            }

            //TODO: PASSWORD INCRIPTING
            var passhash = user.Password;

            var newUser = new User()
            {
                Login = user.Login,
                PasswordHash = passhash,
                Name = user.Name,
                LastName = user.LastName
            };

            _plansDbContext.Users.Add(newUser);
            _plansDbContext.SaveChanges();

            return Token(user.Login, user.Password);
        }
    }
}