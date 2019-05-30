using MusicMall.Areas.Admin.Models;
using MusicMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMall.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Order/Order
        public ActionResult Index(int pageNum = 1, int pageSize = 20, string keyword = "")
        {
            IQueryable<t_order> iq = db.t_order;
            ViewBag.keyword = keyword;
            if (keyword != "")
            {
                iq = iq.Where(w => w.orderno.Contains(keyword));
            }
            int count = iq.Count();
            var users = iq.OrderBy(o => o.id).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.page = new PageModel(count, pageSize, pageNum);
            return View(users);
        }

        // GET: Order/Order/Details/5
        public ActionResult Details(int id)
        {
            var srder = db.t_order.Find(id);
            return View(srder);
        }

        // GET: Order/Order/Edit/5
        public ActionResult Edit(int id)
        {
            var srder = db.t_order.Find(id);
            return View(srder);
        }

        // POST: Order/Order/Edit/5
        [HttpPost]
        public ActionResult Edit(t_order srder)
        {
            var data = db.t_order.Where(w => w.id == srder.id).First();
            data = Common.Common.MapperToModel<t_order, t_order>(data, srder);
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

        // POST: Order/Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var srder = db.t_order.Find(id);
                db.t_order.Remove(srder);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch (Exception)
            {

                return Json(new JsonData("no", message: "删除失败！"));
            }
        }

        // POST: Order/Order/DeleteAll/5,3
        [HttpPost]
        public ActionResult DeleteAll(params int[] ids)
        {
            try
            {
                // 字符串形式 in(1,2,3,4,5) ids == string
                //int[] intIds = ids.Split(',').Select(int.Parse).ToArray();
                //var users = db.t_order.Where(w => intIds.Contains(w.id));
                //db.t_order.RemoveRange(users);
                foreach (var item in ids)
                {
                    var srder = db.t_order.Find(item);
                    db.t_order.Remove(srder);
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
                t_order srder = db.t_order.First(w => w.id == id);
                srder.status = status;
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