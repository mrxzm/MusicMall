using MusicMall.Areas.Admin.Models;
using MusicMall.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMall.Areas.Admin.Controllers
{
    public class MusicController : BaseController
    {
        // GET: Music/Music
        public ActionResult Index(int pageNum = 1, int pageSize = 20, string keyword = "")
        {
            IQueryable<t_music> iq = db.t_music;
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

        // GET: Music/Music/Details/5
        public ActionResult Details(int id)
        {
            var t_music = db.t_music.Find(id);
            return View(t_music);
        }

        // GET: Music/Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Music/Music/Create
        [HttpPost]
        public ActionResult Create(t_music t_music)
        {
            try
            {
                //补充数据
                t_music.createTime = DateTime.Now;
                t_music.updateTime = DateTime.Now;

                db.t_music.Add(t_music);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "创建失败！"));
            }
        }

        // GET: Music/Music/Edit/5
        public ActionResult Edit(int id)
        {
            var t_music = db.t_music.Find(id);
            return View(t_music);
        }

        // POST: Music/Music/Edit/5
        [HttpPost]
        public ActionResult Edit(t_music t_music)
        {
            var data = db.t_music.Where(w => w.id == t_music.id).First();
            data = Common.Common.MapperToModel<t_music, t_music>(data, t_music);
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

        // POST: Music/Music/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var t_music = db.t_music.Find(id);
                db.t_music.Remove(t_music);
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch (Exception)
            {

                return Json(new JsonData("no", message: "删除失败！"));
            }
        }

        // POST: Music/Music/DeleteAll/5,3
        [HttpPost]
        public ActionResult DeleteAll(params int[] ids)
        {
            try
            {
                // 字符串形式 in(1,2,3,4,5) ids == string
                //int[] intIds = ids.Split(',').Select(int.Parse).ToArray();
                //var users = db.t_music.Where(w => intIds.Contains(w.id));
                //db.t_music.RemoveRange(users);
                foreach (var item in ids)
                {
                    var t_music = db.t_music.Find(item);
                    db.t_music.Remove(t_music);
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
                t_music t_music = db.t_music.First(w => w.id == id);
                t_music.status = status;
                db.SaveChanges();
                return Json(new JsonData("ok"));
            }
            catch
            {
                return Json(new JsonData("no", message: "更改失败！"));
            }
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpLoadFile(HttpPostedFileBase fileData)
        {
            string newName;
            if (fileData != null && fileData.ContentLength > 0)
            {
                string fileSave = Server.MapPath("~/UploadFiles/");
                //获取文件的扩展名
                string extName = Path.GetExtension(fileData.FileName);
                //得到一个新的文件名称
                newName = Guid.NewGuid().ToString() + extName;
                fileData.SaveAs(Path.Combine(fileSave, newName));
                return Json(new JsonData("ok", data: newName));
            }
            return Json(new JsonData("no", message: "上传失败！"));

        }

    }
}
