<%@ Page Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="TihBlogCompact.Authors" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
<!-- No Author Selected View -->
  <asp:Panel ID="_noauthorPanel" runat="server">
   <div style="text-align:center; padding-top:10px;">
     <asp:Label ID="_errorAuthorIdLbl" CssClass="errorLabel" runat="server"></asp:Label>
   </div>
  </asp:Panel>
  <!-- / No Author Selected View -->
  <!-- Author View -->
  <asp:Panel ID="_authorPanel" runat="server"> 
   <!-- Article -->
   <asp:Repeater ID="_authorRepeater" runat="server" DataSourceID="_authorDS">
    <ItemTemplate>
      <div class="div_left" style="margin-right:10px;">
        <asp:Image ID="_authorPhotoImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "pictureURL")%>' />
      </div>
      <div style="text-align:center; border-width:0px;" class="article_title"><%# DataBinder.Eval(Container.DataItem, "names")%></div>
      <div>
        <%# DataBinder.Eval(Container.DataItem, "resume")%>
      </div>
    </ItemTemplate>
   </asp:Repeater>
   <tasp:TBAccessDataSource ID="_authorDS" runat="server" 
             SelectCommand="SELECT [names], 
                                   [resume],
                                   [pictureURL]
                            FROM [Authors]
                            WHERE [ID]=@ID" OnInit="_authorDS_Init">
        <SelectParameters>
            <asp:Parameter Name="ID" Type="Int64" />
        </SelectParameters>
   </tasp:TBAccessDataSource>
   <!-- / Author -->
  </asp:Panel>
  <br />
  <br />
  <br />
  <br />
  <!-- Article View -->
  <asp:Panel ID="Panel1" runat="server">
        <h2>Published Articles:</h2>
        <div>
            <asp:Repeater ID="_authorArticleTitle" runat="server" DataSourceID="_articleTitles">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>                                                            
                            <li><a class="simple_link" href='Article.aspx?articleId=<%# DataBinder.Eval(Container.DataItem, "ID") %>'><%# DataBinder.Eval(Container.DataItem, "title") %></a></li>                       
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <tasp:TBAccessDataSource ID="_articleTitles" runat="server" SelectCommand="SELECT [title], [ID] FROM [Articles] WHERE [authorId]=@authorId" OnInit="_authorArticleTitle_Init">
            <SelectParameters>
                <asp:Parameter Name="authorId" Type= "Int64" />
            </SelectParameters>
        </tasp:TBAccessDataSource>
  </asp:Panel>
  <!-- / Article View -->
</asp:Content>
