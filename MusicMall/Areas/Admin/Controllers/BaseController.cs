using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMall.Areas.Admin.Infrastructure;
using MusicMall.Controllers;

namespace MusicMall.Areas.Admin.Controllers
{
    [PowerAuthAttribute]
    public class BaseController : CommonController
    {
        
    }
}