﻿using System.Web;
using System.Web.Optimization;

namespace MusicMall
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            /****************************************** Admin 资源 ****************************************************/

            //js
            bundles.Add(new ScriptBundle("~/js/xadmin").Include("~/Areas/Admin/Content/js/xadmin.js"));
            bundles.Add(new ScriptBundle("~/js/xcity").Include("~/Areas/Admin/Content/js/xcity.js"));

            //css
            bundles.Add(new StyleBundle("~/css/font").Include("~/Areas/Admin/Content/css/font.css"));
            bundles.Add(new StyleBundle("~/css/xadmin").Include("~/Areas/Admin/Content/css/xadmin.css"));

            //layer
            bundles.Add(new ScriptBundle("~/js/layui").Include("~/Areas/Admin/Content/lib/layui/layui.js"));
            //E:\webTest\MusicMall\MusicMall\Areas\Admin\Content\lib\layui\lay\modules\laypage.js
            //bundles.Add(new ScriptBundle("~/js/laypage").Include("~/Areas/Admin/Content/lib/layui/lay/modules/laypage.js"));


            /****************************************** END *********************************************************/


            /****************************************** Home 资源 ****************************************************/

            //js
            bundles.Add(new ScriptBundle("~/js/classie").Include("~/Areas/Home/Content/js/classie.js"));
            bundles.Add(new ScriptBundle("~/js/uisearch").Include("~/Areas/Home/Content/js/uisearch.js"));

            //css
            bundles.Add(new StyleBundle("~/css/theme").Include("~/Areas/Home/Content/css/style.css"));
            bundles.Add(new StyleBundle("~/css/font-awesome").Include("~/Areas/Home/Content/css/font-awesome.css"));

            //chocolat
            bundles.Add(new ScriptBundle("~/js/chocolat").Include("~/Areas/Home/Content/js/jquery.chocolat.js"));
            bundles.Add(new StyleBundle("~/css/chocolat").Include("~/Areas/Home/Content/css/chocolat.css"));
            
            /****************************************** END *********************************************************/

        }
    }
}
