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
        // GET: Admin/User
        public ActionResult Index(int pageNum = 0, int pageSize = 30, string keyword = "")
        {
            IQueryable < t_admin > iq = db.t_admin;
            if (keyword != "")
            {
                keyword = "%" + keyword + "%";
                iq.Where(w => w.name == keyword);
            }
            if (pageNum != 0)
            {
                pageNum--;
            }
            var users = iq.OrderBy(o => o.id).Skip(pageNum * pageSize).Take(pageSize).ToList();
            return View(users);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            var user = db.t_admin.Find(id);
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(t_admin admin)
        {
            try
            {
                db.t_admin.Add(admin);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", "创建失败！"));
            }
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = db.t_admin.Find(id);
            return View(user);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(t_admin admin)
        {
            try
            {
                var data = db.t_admin.Where(w => w.id == admin.id).First();
                data = Common.Common.MapperToModel<t_admin, t_admin>(admin, data);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", "创建失败！"));
            }
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var admin = db.t_admin.Find(id);
                db.t_admin.Remove(admin);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch (Exception)
            {

                return Json(new JsonData("no", message:"删除失败！"));
            }
        }

        // POST: Admin/User/DeleteAll/5/3
        [HttpPost]
        public ActionResult DeleteAll(params int[] ids)
        {
            try
            {
                // 字符串形式 in(1,2,3,4,5) ids == string
                //var admins = db.t_admin.Where(w => ids.Contains(w.id));
                //db.t_admin.RemoveRange(admins);
                
                foreach (var item in ids)
                {
                    var admin = db.t_admin.Find(item);
                    db.t_admin.Remove(admin);
                }
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "删除失败！"));
            }
        }
    }
}
