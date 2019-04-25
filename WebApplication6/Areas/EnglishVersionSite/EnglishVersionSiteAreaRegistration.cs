using System.Web.Mvc;

namespace WebApplication6.Areas.EnglishVersionSite
{
    public class EnglishVersionSiteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EnglishVersionSite";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EnglishVersionSite_default",
                "EnglishVersionSite/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}