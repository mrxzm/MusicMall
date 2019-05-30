using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMall.Models;

namespace MusicMall.Controllers
{

    public class CommonController : Controller
    {
        // 实例化数据库上下文
        public EfContext db = new EfContext();
    }
}