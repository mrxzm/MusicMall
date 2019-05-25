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
    public class UserController : BaseController
    {
        // GET: User/User
        public ActionResult Index(int pageNum = 1, int pageSize = 20, string keyword = "")
        {
            IQueryable < t_user > iq = db.t_user;
            ViewBag.keyword = keyword;
            if (keyword != "")
            {
                iq = iq.Where(w => w.name.Contains(keyword));
            }
            int count = iq.Count();
            var users = iq.OrderBy(o => o.id).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            
            ViewBag.page = new PageModel(count, pageSize, pageNum);
            return View(users);
        }

        // GET: User/User/Details/5
        public ActionResult Details(int id)
        {
            var user = db.t_user.Find(id);
            return View(user);
        }

        // GET: User/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/User/Create
        [HttpPost]
        public ActionResult Create(t_user user)
        {
            try
            {
                //补充数据
                user.password = Common.Common.EncryptionPassword(user.password, ConfigurationSettings.AppSettings["salt"]);
                user.loginCount = 1;
                user.loginTime = DateTime.Now;
                user.loginIp = Request.UserHostAddress;
                user.createTime = DateTime.Now;
                user.updateTime = DateTime.Now;

                db.t_user.Add(user);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "创建失败！"));
            }
        }

        // GET: User/User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = db.t_user.Find(id);
            return View(user);
        }

        // POST: User/User/Edit/5
        [HttpPost]
        public ActionResult Edit(t_user user)
        {
            var data = db.t_user.Where(w => w.id == user.id).First();
            data = Common.Common.MapperToModel<t_user, t_user>(data, user);
            data.updateTime = DateTime.Now;
            db.SaveChanges();
            try
            {
                
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message:"修改失败！"));
            }
        }

        // POST: User/User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = db.t_user.Find(id);
                db.t_user.Remove(user);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch (Exception)
            {

                return Json(new JsonData("no", message:"删除失败！"));
            }
        }

        // POST: User/User/DeleteAll/5,3
        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            try
            {
                // 字符串形式 in(1,2,3,4,5) ids == string
                int[] intIds = ids.Split(',').Select(int.Parse).ToArray();
                var users = db.t_user.Where(w => intIds.Contains(w.id));
                db.t_user.RemoveRange(users);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "删除失败！"));
            }
        }

        [HttpPost]
        public ActionResult Status(int id, bool status)
        {
            try
            {
                t_user user = db.t_user.First(w => w.id == id);
                user.status = status;
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "更改失败！"));
            }
        }

    }
}
