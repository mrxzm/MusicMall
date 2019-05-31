using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMall.Areas.Admin.Infrastructure;
using MusicMall.Areas.Admin.Models;
using MusicMall.Controllers;

namespace MusicMall.Areas.Admin.Controllers
{
    [PowerAuthAttribute]
    public class BaseController : CommonController
    {

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