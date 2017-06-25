using System;
using System.Linq;
using SavingLittleSouls.DataHelpers;
using SavingLittleSouls.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SavingLittleSouls.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {

        private ApplicationDbContext _dbContext;

        public AdminController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loginUser = _dbContext.Users.Include(t => t.Role).Where(p => p.UserName == user.UserName && p.Password == user.Password).SingleOrDefault();
                    if (loginUser != null)
                    {
                        var Issuer = "localhost:4200";
                        var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name,loginUser.FirstName + " " + loginUser.LastName ,ClaimValueTypes.String,Issuer),
                        new Claim(ClaimTypes.Role,loginUser.Role.RoleName,ClaimValueTypes.String,Issuer),
                        new Claim(ClaimTypes.NameIdentifier,loginUser.UserName,ClaimValueTypes.String,Issuer)
                    };
                        var userIdentity = new ClaimsIdentity(claims,"ApplicationCookie",ClaimTypes.Name,ClaimTypes.Role);
                        var userPrincipal = new ClaimsPrincipal(userIdentity);

                        HttpContext.Current.GetOwinContext().Authentication.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = false,
                            AllowRefresh = false,
                        }, userIdentity);

                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            return Unauthorized();
        }

        [Route("logout")]
        [HttpGet]
        public IHttpActionResult Logout()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut("AuthCookie");
            return Ok();
        }
    }
}
