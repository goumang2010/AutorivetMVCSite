using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoumangToolKit46;
using GoumangToolKit;
using MongoDB.Bson;

namespace DataCollectTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongoMethod = new LoveBADB();
           var tt= mongoMethod.UpdateDBfromFile(@"\\192.168.3.32\Autorivet\Prepare\INFO\MATERIAL\52\BM9000\content2\part\B02");

            tt.Start();


        }

        //扫描标准件手册



    }
}
