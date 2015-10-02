<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminArticles.aspx.cs" Inherits="TihBlogCompact.Admin.adminArticles" ValidateRequest="false" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/Controls/categoriesControl.ascx" TagName="CategoriesControl" TagPrefix="controls" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div style="border-width:0px;" class="article_title">
    <%= Resources.Resources.Articles %>
  </div>
  <asp:GridView ID="_articlesGV" runat="server" AllowPaging="True" AllowSorting="True" SkinID="AdminGridSkin"
    AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="_articlesDS" PageSize="5" 
    AutoGenerateEditButton="true" OnRowDeleting="_articlesGV_RowDeleting" OnRowUpdating="_articlesGV_RowUpdating">
    <Columns>
      <asp:TemplateField HeaderText="">
        <ItemTemplate>
          <asp:LinkButton ID="_deleteLnkBtn" runat="server" CommandName="Delete" Text="Delete" CssClass="controlBtn_link"
               OnClientClick="return confirm('Are you sure you want to delete this article? (All comments for that article will be deleted, too.)');">
          </asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />      
      <asp:TemplateField HeaderText="Allow<br />Comments">
        <ItemTemplate>
         <tasp:TBCheckBox ID="_allowCommentsChB" runat="server" TBChecked='<%# DataBinder.Eval(Container.DataItem, "allowComments") %>' Text="" Enabled="false"></tasp:TBCheckBox>
        </ItemTemplate>
        <EditItemTemplate>
         <tasp:TBCheckBox ID="_allowCommentsChB" runat="server" TBChecked="<%# Bind('allowComments') %>" Text="" Enabled="true"></tasp:TBCheckBox>
        </EditItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Content">
        <ItemTemplate>
          <%# DataBinder.Eval(Container.DataItem, "content") %>
        </ItemTemplate>
        <EditItemTemplate>
          <FCKeditorV2:FCKeditor ID="_fckEditor" Width="500px" Height="350px" 
            ToolbarSet="TihBlogAdmin" ToolbarCanCollapse="false" runat="server" Value="<%# Bind('content') %>"
            BasePath="~/editor/" />
        </EditItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Categories">
        <ItemTemplate>
          <%# GetCategoriesForArticle(DataBinder.Eval(Container.DataItem, "ID")) %>
        </ItemTemplate>
        <EditItemTemplate>
            <controls:CategoriesControl ID="_categoriesControl" runat="server" AutomaticInitForArticleId='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
        </EditItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="published" HeaderText="published" ReadOnly="true" SortExpression="published" />
    </Columns>
  </asp:GridView>
  <tasp:TBAccessDataSource ID="_articlesDS" runat="server" 
          SelectCommand="SELECT [ID], 
                                [title], 
                                [authorId], 
                                [published], 
                                [allowComments], 
                                [content] 
                         FROM [Articles] 
                         ORDER BY [published] DESC"
          UpdateCommand="UPDATE [Articles] 
                         SET [title]=@title, 
                             [allowComments]=@allowComments,
                             [content]=@content
                         WHERE [ID]=@ID"
          DeleteCommand="DELETE 
                         FROM [Articles]
                         WHERE [ID]=@ID">
            <UpdateParameters>
              <asp:Parameter Name="title" Type="String" />
              <asp:Parameter Name="allowComments" Type="Int32" />
              <asp:Parameter Name="ID" Type="Int64" />
            </UpdateParameters>
            <DeleteParameters>
              <asp:Parameter Name="ID" Type="Int64" />
            </DeleteParameters>
  </tasp:TBAccessDataSource>
</asp:Content>
