using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutorivetMVC.Models;
using MongoDB.Bson;

namespace AutorivetMVC.Controllers
{
    public class BASearchController : Controller
    {
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
                return p;
            }
            
            ).ToJson();
            return json;
        }



    }
}