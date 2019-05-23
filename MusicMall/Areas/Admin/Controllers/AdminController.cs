using MusicMall.Areas.Admin.Models;
using MusicMall.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMall.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin/Admin/Edit/5
        public ActionResult Edit()
        {
            int id = int.Parse(Session["userid"].ToString());
            t_admin admin = db.t_admin.Find(id);
            return View(admin);
        }

        // POST: Admin/Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string OriginalPassword, string newPassword, string newPassword2)
        {
            try
            {
                if (newPassword == newPassword2)
                {
                    string pass = Common.Common.EncryptionPassword(OriginalPassword, ConfigurationSettings.AppSettings["salt"]);
                    var admin = db.t_admin.Where(w => w.password == pass && w.id == id).FirstOrDefault();
                    if (admin != null)
                    {
                        admin.password = Common.Common.EncryptionPassword(newPassword, ConfigurationSettings.AppSettings["salt"]);
                        db.SaveChanges();
                        return Json(new JsonData("ok"));
                    }
                    return Json(new JsonData("no", message: "原密码错误"));

                }
                else
                {
                    return Json(new JsonData("no", message: "新密码不匹配！"));
                }
                
            }
            catch
            {
                return Json(new JsonData("no", message: "修改失败，请检查密码是否正确！"));
            }
        }
    }
}
