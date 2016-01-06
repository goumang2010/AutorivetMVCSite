using System.Collections.Generic;
using GoumangToolKit;

namespace AutorivetMVC.Models
{
    public  class Product : IProduct
    {
        public string ProgramNum
        {
            get;
            set;
        }

        public string ProductEngName
        {
            get;

        }
        public string ProductChnName
        {
            get;
            set;
        }

        public string CurrentBatch
        {
            get;
            set;
        }

        public string StationNum
        {
            get;
            set;
        }

        public string ProductNum
        {
            get;
            set;


        }



        public string rncnote { get; set; }
        public string note { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string transferdate { get; set; }
        public List<string> rnclist { get; set; }
        public string state { get; set; }














    }
}
