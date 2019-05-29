using System.Web.Mvc;
using System.Web.Routing;

namespace MusicMall.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Home";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            
            context.MapRoute(
                "Home_default",
                "Home/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                 namespaces: new[] { "MusicMall.Areas.Home.Controllers" }
            );

            //context.Routes.Add("ImagesRoute", new Route ("Images/{filename}", new MvcRouteHandler()));
        }
    }
}