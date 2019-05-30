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
    public class SingerController : BaseController
    {
        // GET: Singer/Singer
        public ActionResult Index(int pageNum = 1, int pageSize = 20, string keyword = "")
        {
            IQueryable<t_singer> iq = db.t_singer;
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

        // GET: Singer/Singer/Details/5
        public ActionResult Details(int id)
        {
            var singer = db.t_singer.Find(id);
            return View(singer);
        }

        // GET: Singer/Singer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Singer/Singer/Create
        [HttpPost]
        public ActionResult Create(t_singer singer)
        {
            try
            {
                //补充数据
                singer.password = Common.Common.EncryptionPassword(singer.password, ConfigurationSettings.AppSettings["salt"]);
                singer.loginCount = 1;
                singer.loginTime = DateTime.Now;
                singer.loginIp = Request.UserHostAddress;
                singer.createTime = DateTime.Now;
                singer.updateTime = DateTime.Now;

                db.t_singer.Add(singer);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "创建失败！"));
            }
        }

        // GET: Singer/Singer/Edit/5
        public ActionResult Edit(int id)
        {
            var singer = db.t_singer.Find(id);
            return View(singer);
        }

        // POST: Singer/Singer/Edit/5
        [HttpPost]
        public ActionResult Edit(t_singer singer)
        {
            var data = db.t_singer.Where(w => w.id == singer.id).First();
            data = Common.Common.MapperToModel<t_singer, t_singer>(data, singer);
            data.updateTime = DateTime.Now;
            db.SaveChanges();
            try
            {

                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "修改失败！"));
            }
        }

        // POST: Singer/Singer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var singer = db.t_singer.Find(id);
                db.t_singer.Remove(singer);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch (Exception)
            {

                return Json(new JsonData("no", message: "删除失败！"));
            }
        }

        // POST: Singer/Singer/DeleteAll/5,3
        [HttpPost]
        public ActionResult DeleteAll(params int[] ids)
        {
            try
            {
                // 字符串形式 in(1,2,3,4,5) ids == string
                //int[] intIds = ids.Split(',').Select(int.Parse).ToArray();
                //var users = db.t_singer.Where(w => intIds.Contains(w.id));
                //db.t_singer.RemoveRange(users);
                foreach (var item in ids)
                {
                    var singer = db.t_singer.Find(item);
                    db.t_singer.Remove(singer);
                }
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
                t_singer singer = db.t_singer.First(w => w.id == id);
                singer.status = status;
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
