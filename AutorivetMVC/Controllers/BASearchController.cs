using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutorivetMVC.Models;
using MongoDB.Bson;
using GoumangToolKit;
using System.Threading.Tasks;

namespace AutorivetMVC.Controllers
{
    public class BASearchController : Controller
    {
        static string BApath = localMethod.GetConfigValue("BA_Basefolder", "DBCfg.py");
        static string Localpath = localMethod.GetConfigValue("BA_SaveNetfolder", "DBCfg.py");
        // GET: BASearch
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var rq = Request.QueryString;
            if (rq.HasKeys())
            {
                var searchString = rq["Search"];
                var dd = await BsonProcess(searchString);
                ViewBag.iniData = dd;
                ViewBag.searchString = searchString;
                return View();

            }
            else
            {
                ViewBag.searchString = "";
                ViewBag.iniData = null;
                return View();
            }
            //lLoveBADoc f = new lLoveBADoc();
            //var ff = await f.FetchData(Search);

        }

        public async System.Threading.Tasks.Task<dynamic> JsonDetails(string Search)
        {
           var bson=await BsonProcess(Search);
            return bson.ToJson();
        }

        public async Task<IEnumerable<BsonDocument>> BsonProcess(string Search)
        {
            lLoveBADoc f = new lLoveBADoc();
            var ff = await f.FetchData(Search);

            //   var res = ff.Result;


            return  ff.Select(delegate (BsonDocument p)

             {
                 p.RemoveAt(0);
                 var lp = p["netpath"].AsString;
                 p["localpath"] = lp.Replace(BApath, Localpath);
                 return p;
             }

              );
        }



    }
}