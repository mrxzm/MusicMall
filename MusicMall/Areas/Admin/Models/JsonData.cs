using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMall.Areas.Admin.Models
{
    public class JsonData
    {

        public JsonData(string state,string title = "", string message = "",object data = null, int errorCode = 200)
        {
            this.state = state;
            this.errorCode = errorCode;
            this.message = message;
            this.title = title;
            this.data = data;
        }

        string state;
        int errorCode;
        string message;
        string title;
        object data;

        public int ErrorCode { get => errorCode; set => errorCode = value; }
        public string Message { get => message; set => message = value; }
        public string Title { get => title; set => title = value; }
        public object Data { get => data; set => data = value; }
        public string State { get => state; set => state = value; }
    }
}