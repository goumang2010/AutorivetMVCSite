using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using System.IO;
using GoumangToolKit46;
using GoumangToolKit;
using System.Text.RegularExpressions;
namespace AutorivetMVC.Models
{
   public  class lLoveBADoc
    {
        MongoMethod model;
        // db.loveBA.ensureIndex({filename:"text",title:"text"})
        public lLoveBADoc()
        {
            var client= (string)(localMethod.GetConfigValue("MONGO_URI","DBCfg.py"));
            var database =(string)(localMethod.GetConfigValue("MONGO_DATABASE", "DBCfg.py"));
            var  collection = (string)(localMethod.GetConfigValue("MONGO_COLNAME", "DBCfg.py"));
            model = new MongoMethod(client, database, collection);
        }
        public async Task<IEnumerable<BsonDocument>> FetchData(string filterstr)
        {
          return  await  model.FetchTextData(filterstr);
        }
    }
}
