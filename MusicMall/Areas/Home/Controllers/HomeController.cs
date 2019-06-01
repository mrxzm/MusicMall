using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMall.Areas.Home.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home/Home
        public ActionResult Index()
        {
            var musics = db.t_music.OrderBy(o => o.createTime).Take(4).ToList();
            return View(musics);
        }
    }
}