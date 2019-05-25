using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMall.Areas.Admin.Models
{
    public class PageModel
    {

        public PageModel(int count, int pageSize, int pageNum)
        {
            this.count = count;
            this.pageNum = pageNum;
            this.pageSize = pageSize;
        }

        int count;
        int pageSize;
        int pageNum;

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int Count { get => count; set => count = value; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get => pageSize; set => pageSize = value; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageNum { get => pageNum; set => pageNum = value; }
    }
}