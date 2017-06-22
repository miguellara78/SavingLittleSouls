//using System;
//using System.Linq;
//using SavingLittleSouls.DataHelpers;
//using SavingLittleSouls.Models;
//using System.Data.Entity;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Security.Claims;
//using System.Web;
//using Microsoft.Owin.Security;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace SavingLittleSouls.Controllers
//{
//    [Route("api/[controller]")]
//    public class AdminController : ApiController
//    {

//        private ApplicationDbContext _dbContext;

//        public AdminController()
//        {
//            _dbContext = new ApplicationDbContext();
//        }

//        [Route("login")]
//        [HttpPost]
//        public async Task<IHttpActionResult> Login([FromBody]User user)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var loginUser = _dbContext.Users.Include(t => t.Role).Where(p => p.UserName == user.UserName && p.Password == user.Password).SingleOrDefault();
//                    if (loginUser != null)
//                    {
//                        var Issuer = "localhost:5000";
//                        var claims = new List<Claim>
//                    {
//                        new Claim(ClaimTypes.Name,loginUser.FirstName + " " + loginUser.LastName ,ClaimValueTypes.String,Issuer),
//                        new Claim(ClaimTypes.Role,loginUser.Role.RoleName,ClaimValueTypes.String,Issuer),
//                        new Claim(ClaimTypes.NameIdentifier,loginUser.UserName,ClaimValueTypes.String,Issuer)
//                    };
//                        var userIdentity = new ClaimsIdentity(claims, "Passport");
//                        var userPrincipal = new ClaimsPrincipal(userIdentity);
//                        HttpContext.Current.GetOwincontext();  
//                        var loginInfo = HttpContext.GetOwinContext().Authentication.GetExternalLoginInfo();
//                        await HttpContext.Current.Authentication.SignInAsync("AuthCookie", userPrincipal, new AuthenticationProperties
//                        {
//                            ExpiresUtc = DateTime.UtcNow.AddMinutes(1.0),
//                            IsPersistent = false,
//                            AllowRefresh = false
//                        });

//                        return Ok();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    return InternalServerError(ex);
//                }
//            }

//            return Unauthorized();
//        }

//        [Route("logout")]
//        [HttpGet]
//        public async Task<IHttpActionResult> Logout()
//        {
//            await HttpContext.Authentication.SignOutAsync("AuthCookie");
//            return Ok();
//        }
//    }
//}
