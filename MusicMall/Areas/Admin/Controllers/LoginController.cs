using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMall.Controllers;
using MusicMall.Models;
using MusicMall.Common;
using MusicMall.Areas.Admin.Models;
using System.Configuration;

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

            string pwd = Common.Common.EncryptionPassword(password, ConfigurationSettings.AppSettings["salt"]);
            var admin = db.t_admin.Where(w => w.name == username && w.password == pwd);
            if (admin.Count() == 1)
            {
                t_admin data = admin.First();
                Session.Add("username", data.name);
                Session.Add("userid", data.id);
                return Json( new JsonData(state : "ok"));
            }
            return Json(new JsonData(state: "no", message: "用户名或密码错误！", errorCode : 1000001));
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("index");
        }
    }
}