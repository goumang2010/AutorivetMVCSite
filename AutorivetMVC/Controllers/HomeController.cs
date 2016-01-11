using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AutorivetMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
         //   return Redirect("http://192.168.3.32/");
        }
        public ActionResult About()
        {
            ViewBag.Message = "可通过Github提交Issue进行新功能建议";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "联系维护者";
            return View();
        }
    }
}