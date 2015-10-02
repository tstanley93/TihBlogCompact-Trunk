<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminComments.aspx.cs" Inherits="TihBlogCompact.Admin.adminComments" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div class="subMenu">
    <div>
      <b><%= Resources.Resources.Filter %>:</b>
    </div>
    <%= Resources.Resources.Articles %>: <asp:DropDownList ID="_articlesDDL" runat="server" DataSourceID="_articlesDS" DataTextField="title" DataValueField="ID" OnPreRender="_articlesDDL_PreRender"></asp:DropDownList>
    <tasp:TBAccessDataSource ID="_articlesDS" runat="server" 
                                          SelectCommand="SELECT [title], [ID] 
                                                         FROM [Articles] 
                                                         ORDER BY [published] DESC">
    </tasp:TBAccessDataSource>
    <div style="text-align:right">
      <asp:UpdatePanel ID="_applyFilterUP" runat="server">
        <ContentTemplate>
          <asp:Button ID="_applyFilterBtn" runat="server" OnClick="_applyFilterBtn_Click"></asp:Button> 
        </ContentTemplate>
      </asp:UpdatePanel>  
    </div>   
    
  </div>
  <div style="border-width:0px;" class="article_title">
    <%= Resources.Resources.Comments %>
  </div>
  <div style="margin-top:15px;">
   <asp:UpdatePanel ID="_commentsUP" runat="server">
    <ContentTemplate>
       <asp:GridView ID="_CommentsGV" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
          DataSourceID="_commentsDS" PageSize="10" AllowPaging="true" AllowSorting="true"
           SkinID="AdminGridSkin">
          <Columns>
              <asp:TemplateField HeaderText="">
                <ItemTemplate>
                 <asp:LinkButton ID="_deleteLnkBtn" runat="server" CommandName="Delete" Text="Delete" CssClass="controlBtn_link"
                    OnClientClick="return confirm('Are you sure you want to delete this comment?');">
                 </asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="title" HeaderText="Article" SortExpression="title" />
              <asp:BoundField DataField="names" HeaderText="names" SortExpression="names" />
              <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
              <asp:BoundField DataField="website" HeaderText="website" SortExpression="website" />
              <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
              <asp:BoundField DataField="published" HeaderText="published" SortExpression="published" ReadOnly="true" />
              <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" ReadOnly="true" />
          </Columns>
       </asp:GridView>
       <tasp:TBAccessDataSource ID="_commentsDS" runat="server" 
          SelectCommand="SELECT C.[ID] as [ID], 
                                C.[articleId] as [articleId], 
                                C.[names] as [names], 
                                C.[email] as [email], 
                                C.[website] as [website], 
                                C.[comment] as [comment], 
                                C.[published] as [published], 
                                C.[country] as [country],
                                A.[title] as [title]
                         FROM [Comments] C
                         LEFT JOIN [Articles] A ON C.[articleId] = A.[ID]
                         ORDER BY C.[published] DESC"
          DeleteCommand="DELETE FROM [Comments]
                         WHERE [ID]=@ID">
       </tasp:TBAccessDataSource>
    </ContentTemplate>
   </asp:UpdatePanel>
  </div>
</asp:Content>
