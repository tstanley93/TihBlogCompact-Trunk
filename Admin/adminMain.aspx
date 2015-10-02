<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminMain.aspx.cs" Inherits="TihBlogCompact.Admin.adminMain" MasterPageFile="~/Admin/adminMain.Master" %>

<asp:Content ID="_mainCOntent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div style="border-width:0px;" class="article_title">
    &nbsp;&nbsp;<%= Resources.Resources.Welcome %>,&nbsp;<%= GetUserName() %>
  </div>
  <div style="height:20px;"></div>
  <%= Resources.Resources.CurrentStatus %>:
  <div class="subMenu">
   <%= Resources.Resources.Comments %>:&nbsp;(<%= Resources.Resources.TotalCount %>:&nbsp;<%= GetCommentsCount() %>,&nbsp;<%= Resources.Resources.Last %>:&nbsp;<%= GetLastPublishedCOmment() %>)
  </div>
  
  <div class="subMenu">
   <%= Resources.Resources.Articles %>:&nbsp;(<%= Resources.Resources.TotalCount %>:&nbsp;<%= GetArticlesCount() %>)
  </div>
  
  <div class="subMenu">
   <%= Resources.Resources.Authors %>:&nbsp;(<%= Resources.Resources.TotalCount %>:&nbsp;<%= GetAuthorsCount() %>)
  </div>
  
</asp:Content>