﻿using System.Web.Mvc;

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
                "{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                 namespaces: new[] { "MusicMall.Areas.Home.Controllers" }
            );
        }
    }
}