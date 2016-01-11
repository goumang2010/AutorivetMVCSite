using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoumangToolKit;
using System.IO;
using System.Data;
namespace WebApplication1
{
    public partial class Rear : System.Web.UI.Page
    {
        protected static DataTable unidt = null;
        protected static string pkg ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                  pkg=  Request.QueryString["pkg"]; 
                 switch(pkg)
{
    case "Rear":
        pkg = "后桶段";
        break;
                     case "Mid":
        pkg = "中机身";
                            break;
}
                if (pkg == "")
                {
                    Response.Write("<script language=javascript>alert('工作包选择有误，请联系管理员');</" + "script>");
                }
                BindData();
            }
        }
        private void BindData(DataTable abc = null)
        {
            if (abc != null)
            {
                GridView1.DataSource = abc;
            }
            else
            {
                GridView1.DataSource = AutorivetDB.otherpw(pkg);
            }
            Label1.Text = pkg + "工艺文件";
            Label1.DataBind();
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
              //  string outputpath = @"\\192.168.3.32\Autorivet\output\INFO\files\";
                //注意此时的CommandArgument表示的是所在行的索引。
                //      int index = int.Parse((string)e.CommandArgument);
                string id = (string)e.CommandArgument;
                string pdfname = id + ".pdf";
             //   string targetpath = outputpath + pdfname;
              //  string sourcepath = AutorivetDB.getpath(id);
                //   Response.Write("<script language=javascript>alert('请重新选择');</" + "script>");  
                //  File.Open(path,FileMode.Open);
                //  ReadPdfOnLine(path);
                string serverpath = "/paperwork/Other/" + pdfname;
                string fail_text = "<script language=javascript>alert('该文件尚未制作，请联系管理员');</" + "script>";
                if (!File.Exists(Server.MapPath(serverpath)))
                {
                    Response.Write(fail_text);
                    return;
                }
                switch (e.CommandName)
                {
                    case "open_ol":
                        Response.Redirect("~/pdf.js-master/web/viewer.html?file=" + serverpath);
                        break;
                    case "open_tl":
                                Response.ContentType = "application/pdf";
                            //     Response.Write("<script>window.showModelessDialog('http://192.168.3.32" + serverpath + "')</script>");
                     //   Response.Write("<script language='javascript'>window.open('" + serverpath + "');</script>");
                     //   Response.Write("<script>window.open('" + serverpath + "','_blank')</script>");
                        Response.Write("<script>window.location='" + serverpath + "'</script>");
                  //  Response.Redirect("http://192.168.3.32" + serverpath);
                        break;
                }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //保持列不变形 
            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                //方法一： 
                e.Row.Cells[i].Text = " " + e.Row.Cells[i].Text + " ";
                e.Row.Cells[i].Wrap = false;
            }
            e.Row.Cells[e.Row.Cells.Count - 1].Visible = false; 
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData(unidt);
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}