<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Other.aspx.cs" Inherits="WebApplication1.Rear" Title="Rear AOI" %>

  <asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1> <asp:Label ID="Label1" runat="server" ></asp:Label></h1>
            </hgroup>
            <p>
                如有疑问，请联系相应工作包负责人。
            </p>
        </div>
    </section>
</asp:Content>    
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
       <%-- <h1><%: Title %>.</h1>--%>
       
    </hgroup>

    <article>
       
        <p>
            请打开你所需要的文件
                  
       </p>     
         
       
      
           <asp:GridView ID="GridView1" runat="server"   OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" Width="1050px"   OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="983px"  BackColor="White" BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="4px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" > 
          
                    <AlternatingRowStyle BackColor="White" />
          
                    <columns>  
                        <asp:templatefield HeaderText="打开方式">  
                            <itemtemplate>  
                                                               <asp:Button ID="open_ol" runat="server" Text="在线"
                                  Width="40"  Font-Size="X-Small" CommandName="open_ol" CommandArgument='<%# Bind("文件编号") %>' />  
                                    <asp:Button  ID="open_tl" runat="server" Text="阅读器"
                               Width="50"  Font-Size="X-Small" CommandName="open_tl" CommandArgument='<%# Bind("文件编号") %>'   />  
                                 
<%--                                        <asp:Button ID="Folder" runat="server" Text="Folder" Font-Size="X-Small"
                                   AutoPostBack="true" Width="40" /> 
                                        <asp:Button ID="Edit" runat="server" Text="Edit" Font-Size="X-Small"
                                   AutoPostBack="true" Width="40" /> 
                                 <asp:Button ID="Prod" runat="server"  Text="Prod" Font-Size="X-Small"
                                   AutoPostBack="true" Width="40" /> --%>
                           </itemtemplate>  
                      </asp:templatefield>  
                     
                     
                     
                      
                     <asp:BoundField DataField='修改日期'  HeaderText="修改日期"   />
                     
                     
                       
                     
                     
                        </columns> 
                 

                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
               

        </asp:GridView> 
           
       
  

         
   
    </article>






</asp:Content>

