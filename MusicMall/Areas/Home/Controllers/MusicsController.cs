using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMall.Areas.Home.Controllers
{
    public class MusicsController : Controller
    {
        // GET: Home/Musics
        public ActionResult Index()
        {
            return View();
        }
    }
}