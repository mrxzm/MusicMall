using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMall.Areas.Home.Controllers
{
    public class SingerController : BaseController
    {
        // GET: Home/Singer
        public ActionResult Index()
        {
            var singers = db.t_singer.OrderBy(o => o.updateTime).ToList();
            return View(singers);
        }
    }
}