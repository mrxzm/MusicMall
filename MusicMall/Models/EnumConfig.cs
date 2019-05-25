using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMall.Models
{

    public static class EnumConfig
    {
        /// <summary>
        /// 性别
        /// </summary>
        public static Dictionary<int, string> Sex = new Dictionary<int, string>
        {
            { 0, "未知"},
            { 1, "男"},
            { 2, "女"},
            { 9, "未说明"},
        };

        /// <summary>
        /// t_user 身份
        /// </summary>
        public static Dictionary<int, string> Role = new Dictionary<int, string>
        {
            {0, "未知" },
            { 1, "普通用户"},
        };

        /// <summary>
        /// 状态
        /// </summary>
        public static Dictionary<bool, string> Status = new Dictionary<bool, string>
        {
            { true, "启用"},
            { false, "禁用"}
        };

        /// <summary>
        /// 是 or 否
        /// </summary>
        public static Dictionary<int, string> YesNo = new Dictionary<int, string>
        {
            { 0, "否"},
            { 1, "是"}
        };

        /// <summary>
        /// 支付类型
        /// </summary>
        public static Dictionary<int, string> PayType = new Dictionary<int, string>
        {
            { 1, "微信" },
            { 2, "支付宝"}
        };
    }

}