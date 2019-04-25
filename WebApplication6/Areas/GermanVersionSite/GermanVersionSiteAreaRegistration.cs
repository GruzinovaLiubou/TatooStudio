using System.Web.Mvc;

namespace WebApplication6.Areas.GermanVersionSite
{
    public class GermanVersionSiteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GermanVersionSite";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GermanVersionSite_default",
                "GermanVersionSite/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}