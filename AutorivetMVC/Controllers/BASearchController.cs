using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutorivetMVC.Models;
using MongoDB.Bson;
using GoumangToolKit;

namespace AutorivetMVC.Controllers
{
    public class BASearchController : Controller
    {
        static string BApath = localMethod.GetConfigValue("BA_Basefolder", "DBCfg.py");
        static string Localpath = localMethod.GetConfigValue("BA_SaveNetfolder", "DBCfg.py");
        // GET: BASearch
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //lLoveBADoc f = new lLoveBADoc();
            //var ff = await f.FetchData(Search);
            return View();
        }

        public async System.Threading.Tasks.Task<dynamic> JsonDetails(string Search)
        {

            lLoveBADoc f = new lLoveBADoc();
            var ff = await f.FetchData(Search);

         //   var res = ff.Result;


           var json= ff.Select(delegate(BsonDocument p)

            {
                p.RemoveAt(0);
                var lp = p["netpath"].AsString;
                p["localpath"] = lp.Replace(BApath, Localpath);
                return p;
            }
            
            ).ToJson();
            return json;
        }



    }
}