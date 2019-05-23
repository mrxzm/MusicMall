using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}