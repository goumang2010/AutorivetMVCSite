using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data;

namespace AutorivetMVC.Controllers
{
    public class ProductionController : Controller
    {
        ProductionCur unimodel = new ProductionCur();
        // GET: Production
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Production()
        {
            ViewBag.Message = "查看并管理生产情况";
          
            return View(unimodel);
        }

        [HttpPost]
        public ActionResult refreshInfo(string product)
        {
            var gh = product.Split('_');
            //return Json(iniProdList(product));
            unimodel.switchSelected(gh[0], gh[1]);
            return View(unimodel);



        }

        [HttpPost]
        public JsonResult refreshRNC(string rnc)
        {
            var rnc_info = (from DataRow p in unimodel.RNCInfo.Rows
                            where p["外部拒收号"].ToString() == rnc
                            select new
                            {
                                innerno = p["内部拒收号"].ToString(),
                                reason = p["拒收原因"].ToString(),
                                state = p["当前状态"].ToString(),
                                correct = p["纠正措施"].ToString(),
                                AAO = p["AAO"].ToString()

                            }).First();




            return Json(rnc_info);




        }
    }
}