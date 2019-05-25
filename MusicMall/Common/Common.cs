using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MusicMall.Common
{
    public static class Common
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string EncryptionPassword(string password, string salt)
        {
            string result = null;

            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            result = Convert.ToBase64String(s);

            return result;
        }


        /// <summary>
        /// 反射实现两个类的对象之间相同属性的值的复制
        /// 适用于没有新建实体之间
        /// </summary>
        /// <typeparam name="D">返回的实体</typeparam>
        /// <typeparam name="S">数据源实体</typeparam>
        /// <param name="d">返回的实体</param>
        /// <param name="s">数据源实体</param>
        /// <returns></returns>
        public static D MapperToModel<D, S>(D d, S s)
        {
            try
            {
                var Types = s.GetType();//获得类型  
                var Typed = typeof(D);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name && dp.PropertyType == sp.PropertyType && dp.Name != "Error" && dp.Name != "Item")//判断属性名是否相同  
                        {
                            var value = sp.GetValue(s, null);
                            if (value != null && value.ToString() != "" && DateTime.MinValue != value as DateTime?) //过滤空数据
                            {
                                dp.SetValue(d, value, null);//获得s对象属性的值复制给d对象的属性 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return d;
        }
    }

}