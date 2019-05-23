using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMall.Controllers;
using MusicMall.Models;
using MusicMall.Common;
using MusicMall.Areas.Admin.Models;

namespace MusicMall.Areas.Admin.Controllers
{
    public class LoginController : CommonController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Validate(string username, string password)
        {
            var test = Request.Params;

            string pwd = Common.Common.EncryptionPassword(password, "123");
            var admin = db.t_admin.Where(w => w.name == username && w.password == pwd);
            if (admin.Count() == 1)
            {
                Session.Add("username", admin.First().name);
                return Json( new JsonData(state : "ok"));
            }
            return Json(new JsonData(state: "no", message: "用户名或密码错误！", errorCode : 1000001));
        }
    }
}