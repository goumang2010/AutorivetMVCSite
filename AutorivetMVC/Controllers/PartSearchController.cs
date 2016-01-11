using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoumangToolKit;
using DBQuery;
using System.Data;
namespace AutorivetMVC.Controllers
{
    public class PartSearchController : Controller
    {
        // GET: PartSearch
        public ActionResult Index()
        {
            return View();
        }
        public  JsonResult JsonDetails(string extention,string SearchText)
        {
            //"<tr><th>查询图号</th><th>有效版次</th><th>下级装配号</th><th>名称</th><th>有效架次</th><th>分工</th><th>操作</th></tr>"
            var lists = SearchText.Split(new Char[2] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();
            var dt = QueryParts.queryDataList(extention, lists).AsEnumerable();
            var result = from pp in dt
                         select new
                         {
                             DrawingNo = pp["查询图号"].ToString(),
                             EffectRev = pp["有效版次"].ToString(),
                             NHA = pp["下级装配号"].ToString(),
                             EngName = pp["名称"].ToString(),
                             EffectBat = pp["有效架次"].ToString(),
                             Work = pp["分工"].ToString(),
                             Href = pp["Href"].ToString().Replace("\\", "\\\\")
                         };
            return Json(result);
        }
    }
}