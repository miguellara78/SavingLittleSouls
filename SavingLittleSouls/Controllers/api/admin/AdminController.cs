using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SavingLittleSouls.DataHelpers;
using SavingLittleSouls.Models;
using Microsoft.AspNetCore.Http.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SavingLittleSouls.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {

        private ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loginUser = _dbContext.Users.Include(t => t.Role).Where(p => p.UserName == user.UserName && p.Password == user.Password).SingleOrDefault();
                    if (loginUser != null)
                    {
                        var Issuer = "localhost:5000";
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,loginUser.FirstName + " " + loginUser.LastName ,ClaimValueTypes.String,Issuer),
                        new Claim(ClaimTypes.Role,loginUser.Role.RoleName,ClaimValueTypes.String,Issuer),
                        new Claim(ClaimTypes.NameIdentifier,loginUser.UserName,ClaimValueTypes.String,Issuer)
                    };

                        var userIdentity = new ClaimsIdentity(claims, "Passport");
                        var userPrincipal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.Authentication.SignInAsync("AuthCookie", userPrincipal, new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(1.0),
                            IsPersistent = false,
                            AllowRefresh = false
                        });

                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Error = ex.Message });
                }
            }

            return Unauthorized();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("AuthCookie");
            return Ok();
        }
    }
}
