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
    public class PayController : BaseController
    {
        // GET: Pay/Pay
        public ActionResult Index(int pageNum = 1, int pageSize = 20, string keyword = "")
        {
            IQueryable<t_pay> iq = db.t_pay;
            ViewBag.keyword = keyword;
            if (keyword != "")
            {
                iq = iq.Where(w => w.type.Contains(keyword));
            }
            int count = iq.Count();
            var pays = iq.OrderBy(o => o.id).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.page = new PageModel(count, pageSize, pageNum);
            return View(pays);
        }

        // GET: Pay/Pay/Details/5
        public ActionResult Details(int id)
        {
            var pay = db.t_pay.Find(id);
            return View(pay);
        }

        // GET: Pay/Pay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pay/Pay/Create
        [HttpPost]
        public ActionResult Create(t_pay pay)
        {
            try
            {
                //补充数据
                pay.payTime = DateTime.Now;
                pay.createTime = DateTime.Now;
                pay.isPay = true;

                db.t_pay.Add(pay);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "创建失败！"));
            }
        }

        // GET: Pay/Pay/Edit/5
        public ActionResult Edit(int id)
        {
            var pay = db.t_pay.Find(id);
            return View(pay);
        }

        // POST: Pay/Pay/Edit/5
        [HttpPost]
        public ActionResult Edit(t_pay pay)
        {
            var data = db.t_pay.Where(w => w.id == pay.id).First();
            data = Common.Common.MapperToModel<t_pay, t_pay>(data, pay);
            
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

        // POST: Pay/Pay/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var pay = db.t_pay.Find(id);
                db.t_pay.Remove(pay);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch (Exception)
            {

                return Json(new JsonData("no", message: "删除失败！"));
            }
        }

        // POST: Pay/Pay/DeleteAll/5,3
        [HttpPost]
        public ActionResult DeleteAll(params int[] ids)
        {
            try
            {
                // 字符串形式 in(1,2,3,4,5) ids == string
                //int[] intIds = ids.Split(',').Select(int.Parse).ToArray();
                //var pays = db.t_pay.Where(w => intIds.Contains(w.id));
                //db.t_pay.RemoveRange(pays);
                foreach (var item in ids)
                {
                    var pay = db.t_pay.Find(item);
                    db.t_pay.Remove(pay);
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
                t_pay pay = db.t_pay.First(w => w.id == id);
                pay.status = status;
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
