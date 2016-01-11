<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="AutorivetFiles.aspx.cs" Inherits="WebApplication1.AutorivetFiles" Title="Autorivet files" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>自动钻铆工艺文件</h1>
            </hgroup>
            <p>
                如有疑问，请联系 <a href="mailto:yu.mingyang@mail.saci.net.cn" title="于明洋">于明洋</a>
                或 <a href="mailto:li.zhongning@mail.saci.net.cn" title="李钟宁">李钟宁</a>。
            </p>
        </div>
    </section>
</asp:Content>    
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<%--      <hgroup class="content-wrapper">
       <%-- <h1><%: Title %>.</h1>--%>
<%--        <h2>全部自动钻铆工艺文件</h2>
    </hgroup>--%>
    <article>
        <p>
            请筛选你所需要的文件
       </p>     
        <p>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="138px">
            <asp:ListItem>全部</asp:ListItem>
            <asp:ListItem>AO</asp:ListItem>
            <asp:ListItem>补铆_AAO</asp:ListItem>
            <asp:ListItem>RNC_AAO</asp:ListItem>
            <asp:ListItem>COS</asp:ListItem>
            <asp:ListItem>TS</asp:ListItem>
            <asp:ListItem>索引</asp:ListItem>
            <asp:ListItem>AOI</asp:ListItem>
        </asp:DropDownList>
            </p>
         <asp:GridView ID="GridView1" runat="server"   OnRowDataBound="GridView1_RowDataBound" AllowPaging="True"   OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="983px" Width="1050px"  BackColor="White" BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="4px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" > 
                    <AlternatingRowStyle BackColor="White" />
                    <columns>  
                        <asp:templatefield HeaderText="打开方式" ControlStyle-Width="80px">  
                            <itemtemplate >  
                                <asp:Button ID="open_ol" runat="server" Text="在线" 
                                  Width="50"  Font-Size="X-Small" CommandName="open_ol" CommandArgument='<%# Bind("文件名") %>' />  
                                    <asp:Button  ID="open_tl" runat="server" Text="阅读器"
                                  Width="50"  Font-Size="X-Small" CommandName="open_tl" CommandArgument='<%# Bind("文件名") %>'   />  
                           </itemtemplate>  
                      </asp:templatefield>  
                        <asp:BoundField DataField='编制日期'  HeaderText="创建日期"  />
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
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="刷新" />
        <p>
            &nbsp;</p>
    </article>
<%--    <aside>
        <h3>aside title</h3>
        <p>        
            use this area to provide additional information.
        </p>
        <ul>
            <li><a runat="server" href="~/">home</a></li>
            <li><a runat="server" href="~/about">about</a></li>
            <li><a runat="server" href="~/contact">contact</a></li>
        </ul>
    </aside>--%>
</asp:Content>
