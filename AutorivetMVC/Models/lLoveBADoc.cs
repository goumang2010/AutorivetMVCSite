using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using System.IO;
using mysqlsolution;
using System.Text.RegularExpressions;

namespace AutorivetMVC.Models
{
   public  class lLoveBADoc
    {
        IMongoCollection<BsonDocument> collection; // initialize to the collection to read from

        // db.loveBA.ensureIndex({filename:"text",title:"text"})
        public lLoveBADoc()
        {
            var client = new MongoClient((string)(localMethod.GetConfigValue("MONGO_URI","DBCfg.py")));
            var database = client.GetDatabase((string)(localMethod.GetConfigValue("MONGO_DATABASE", "DBCfg.py")));
            collection = database.GetCollection<BsonDocument>((string)(localMethod.GetConfigValue("MONGO_COLNAME", "DBCfg.py")));


        }
        public async Task<IEnumerable<BsonDocument>> FetchData(string filterstr)
        {
            string regEx = "-";
            var array= Regex.Split(filterstr, regEx,RegexOptions.IgnoreCase);
            string querystr = "";
            if (array.Count()==1)
            {
                querystr = filterstr;
            }
            else
            {
                foreach (var pp in array)
                {
                    querystr = querystr + "\"" + pp + "\"";

                }
            }

           

            var filter = Builders<BsonDocument>.Filter.Eq("$text",new BsonDocument { { "$search", querystr } });
            List<string> dd=new List<string>();
            return  await  collection.Find(filter).ToListAsync();
            }
    }
}
