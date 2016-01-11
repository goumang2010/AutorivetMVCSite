using System.Collections.Generic;
using System.Linq;
using GoumangToolKit;
using System.Data;
using AutorivetMVC.Models;
namespace MvcApplication1.Models
{
    public  class ProductionCur
    {
     public  List<Product> Products;
      Product selectedProduct;
      private DataTable allinfo;
        private DataTable rncinfo;
      public  ProductionCur()
     {
           AllInfo = AutorivetDB.production_view();
     }
        public void switchSelected(string productChnName,string fuseNO)
        {
            var ff=Products.Where(p => p.ProductChnName == productChnName && p.CurrentBatch == fuseNO);
            if(ff.Count()>0)
            {
                SelectedProduct = ff.First();
            }
        }
        public DataTable AllInfo
      {
            get
          {
              return allinfo;
          }
            set
          {
               allinfo = value;
                rncinfo = AutorivetDB.RNC_view();
              var jj=  from pp in allinfo.AsEnumerable().GroupBy(p=> p["产品名称"].ToString())
                       join rr in rncinfo.AsEnumerable()
                 on pp.Key equals rr["关联产品"].ToString()
                 into hh
                select new
                {
                    key= pp.Key,
                    rncls=hh
                };
                var rncdic = jj.ToDictionary(aa => aa.key, bb => bb.rncls);
                Products = new List<Product>();
                Products = (from pp in allinfo.AsEnumerable()
                            select new Product()
                            {
                                ProductChnName = pp["产品名称"].ToString(),
                                StationNum = pp["站位号"].ToString(),
                                ProductNum = pp["图号"].ToString(),
                                CurrentBatch = pp["产品架次"].ToString(),
                                startdate = pp["开始日期"].ToString(),
                                enddate = pp["结束日期"].ToString(),
                                transferdate = pp["移交日期"].ToString(),
                                state= pp["当前状态"].ToString(),
                                rncnote = pp["备注"].ToString(),
                                note = pp["状态说明"].ToString(),
                                rnclist = rncdic[pp["产品名称"].ToString()].Select(p=>p["外部拒收号"].ToString()).ToList()
                            }).ToList();
                selectedProduct = Products.Last();
          }
      }
        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
            }
        }
        public DataTable RNCInfo
        {
            get;
            set;
        }
        //public string zhanwei { get; set; }
        //public string state { get; set; }
        //public string rncnote { get; set; }
        //public string note { get; set; }
        //public string startdate { get; set; }
        //public string enddate { get; set; }
        //public string transferdate { get; set; }
        //public List<string> rnclist { get; set; }
    }
}