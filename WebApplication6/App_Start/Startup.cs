using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Project.Logic.Mappings;
using System.Web.Services.Description;

[assembly: OwinStartup(typeof(Website.App_Start.Startup))]

namespace Website.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/LogInPage"),
            });
            MappingConfiguration.Configure();
        }

    }
}