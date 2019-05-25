using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using MusicMall.Models;

namespace MusicMall.Common
{
    public static class LinqExtend
    {
        public static IQueryable<T> FormatData<T>(this IQueryable<T> source)
        {
            foreach (var item in source)
            {
                //读取EnumConfig 名称 对比
                
            }

            return source;
        }

        public static T FormatData<T>(this T source)
        {
            Type type = source.GetType();
            Type typeConfig = typeof(EnumConfig);
            foreach (PropertyInfo item in type.GetProperties())
            {
                foreach (PropertyInfo config in typeConfig.GetRuntimeProperties())
                {
                    //首字母小写 （忽略首字母大小写不匹配）
                    string strTopItem = item.Name.Substring(0, 1).ToLower() + item.Name.ToString();
                    string strTopConfig = config.Name.Substring(0, 1).ToLower() + config.Name.Substring(1);
                    if (strTopConfig == strTopItem)
                    {
                        var valueItem = item.GetValue(type, null);
                        var valueConfig = config.GetValue(null, null);
                        Dictionary<object, string> pairs = valueConfig as Dictionary<object, string>;
                        foreach (var par in pairs)
                        {
                            if (par.Key.ToString() == valueItem.ToString())
                            {
                                //TODO 这个。。。发现字段类型不匹配貌似不能这样玩，还是得重新生成对象 胎死腹中
                            }
                        }
                    }
                }
                
            }
            return source;
        }
    }
}