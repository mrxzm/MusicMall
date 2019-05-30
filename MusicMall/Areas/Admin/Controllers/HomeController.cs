using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMall.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            DateTime startTime = DateTime.Now.Date;
            DateTime endTime = DateTime.Now.Date.AddDays(1);
            //今日订单数
            try
            {
                int orderCount = db.t_order.Where(w => w.createTime < endTime && w.createTime > startTime).Count();
                ViewBag.orderCount = orderCount;
                //今日订单总金额
                decimal? orderMoney = db.t_order.Where(w => w.createTime < endTime && w.createTime > startTime).Sum(s => s.total);
                ViewBag.orderMoney = orderMoney == null ? 0 : orderCount;
            }
            catch
            {
            }
            
            return View();
        }
    }
}