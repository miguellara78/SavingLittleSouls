using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(SavingLittleSoulsAPI.Startup))]

namespace SavingLittleSoulsAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions{
                AuthenticationType = "ApplicationCookie",
                ExpireTimeSpan = TimeSpan.FromMinutes(5)
            });
        }
    }
}
