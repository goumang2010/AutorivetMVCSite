using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoumangToolKit;

namespace WebApplication1
{
    public partial class InputFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  // GridView1.DataSource = AutorivetDB.TVA_fstlist("C01322200-001");
          //  GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = AutorivetDB.TVA_fstlist("C01322200-001");
            GridView1.DataBind();
        }
    }
}