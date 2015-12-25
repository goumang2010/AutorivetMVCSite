using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoumangToolKit;
using System.Data;
using System.IO;
using FileManagerNew;

namespace WebApplication1
{
    public partial class AutorivetProduct : System.Web.UI.Page
    {
       protected static DataTable unidt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {

                BindData();
              //  int ll = this.GridView1.Columns.Count - 1;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header) 
{ 
               
//保持列不变形 
for (int i = 1; i < e.Row.Cells.Count-1; i++) 
{ 
//方法一： 

e.Row.Cells[i].Text = " " + e.Row.Cells[i].Text + " "; 
e.Row.Cells[i].Wrap = false; 
//方法二： 
//e.Row.Cells[i].Text = "<nobr> " + e.Row.Cells[i].Text + " </nobr>"; 
}
e.Row.Cells[e.Row.Cells.Count-1].Visible=false; 

} 


        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BindData(DataTable abc=null)
        {
            if(abc!=null)
            {
                GridView1.DataSource = abc;
               
            }
            else
            {
                GridView1.DataSource = AutorivetDB.paperwork_view(0);
            }
            GridView1.DataBind();
         
        } 
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            BindData(unidt);
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
                int i=DropDownList1.SelectedIndex;
            if(i>0)
            {
                //第二个参数指定不输出地址
                unidt = AutorivetDB.ppworkviewrf(i,1);
                     BindData(unidt);
            }
            else
            {
                unidt = null;
                BindData();
            }
         
        }
        #region 在线读取pdf
        public static void ReadPdfOnLine(string filename)
        {
            HttpContext.Current.Response.ContentType = "Application/pdf";
            HttpContext.Current.Response.WriteFile(filename);
            HttpContext.Current.Response.End();
        }
        #endregion
        private void CreateData(string path,string filename)
        {
            string filePath = path;//路径      
            byte[] data = null;
            if (File.Exists(filePath))
            {
                FileInfo DownloadFile = new FileInfo(filePath);

                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = false;
                //Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
                Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());

                switch (DownloadFile.Extension.ToLower())//这是必须，电脑上浏览就不需要
                {
                    case ".pdf":
                        Response.ContentType = "application/pdf";
                        break;
                    case ".txt":
                        Response.ClearHeaders();
                        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(DownloadFile.FullName, System.Text.Encoding.ASCII));
                        Response.ContentType = "text/plain";
                        break;
                    case ".jpg":
                        Response.ContentType = "image/jpeg";
                        break;
                    case ".doc":
                        Response.ContentType = "application/msword";
                        break;
                    case ".zip":
                        Response.ContentType = "application/zip";
                        break;
                    case ".rar":
                        Response.ContentType = "application/rar";
                        break;
                    case ".xls":
                        //Response.ContentType = "application/xls";
                        Response.ContentType = "application/vnd.ms-excel";
                        break;
                    default:
                        Response.ContentType = "application/unknown";
                        break;
                }
                Response.WriteFile(path);
                Response.Flush();
                Response.End();

            }
            else
            {
                Response.Write("<script language=javascript>alert('请重新选择');</" + "script>"); 
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string outputpath = @"\\192.168.3.32\Autorivet\output\INFO\files\";

            //注意此时的CommandArgument表示的是所在行的索引。

            //      int index = int.Parse((string)e.CommandArgument);

            string id = (string)e.CommandArgument;
            string pdfname = id.Split('.')[0] + ".pdf";
            string serverpath = "/paperwork/Autorivet/" + pdfname;
            string fail_text = "<script language=javascript>alert('该文件尚未制作，请联系管理员');</" + "script>";
            if (!File.Exists(Server.MapPath(serverpath)))
            {
                Response.Write(fail_text);
                return;
            }

            switch(e.CommandName)
            {

              

                case "open_ol":

                  
                        Response.Redirect("~/pdf.js-master/web/viewer.html?file=" + serverpath);
                   
                    break;

                case "open_tl":
                  //  Response.ContentType = "application/pdf";
                  //  Response.Write("<script>window.showModelessDialog('http://192.168.3.32" + serverpath + "')</script>");
                   // Response.Write("<script language='javascript'>window.open('" + serverpath + "');</script>");
                  //  Response.Write("<script>window.open('"+serverpath+"','_blank')</script>");
                    Response.Write("<script>window.location='" + serverpath + "'</script>");
                //  Response.Redirect("http://192.168.3.32" + serverpath);

                    break;




            }



        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}