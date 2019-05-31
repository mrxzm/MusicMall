using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMall.Areas.Home.Controllers
{
    public class MusicsController : BaseController
    {
        // GET: Home/Musics
        public ActionResult Index()
        {
            var musics = db.t_music.OrderBy(o => o.createTime).Take(9).ToList();
            return View(musics);
        }
    }
}