<%@ Page Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="article.aspx.cs" Inherits="TihBlogCompact.Article" %>
<%@ Register Src="~/Controls/commentsControl.ascx" TagName="CommentsControl" TagPrefix="controls" %>
<%@ Register Assembly="RssToolkit, Version=1.0.0.1, Culture=neutral, PublicKeyToken=02e47a85b237026a" Namespace="RssToolkit" TagPrefix="cc1" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <!-- No Article Selected View -->
  <asp:Panel ID="_noarticlePanel" runat="server">
   <div style="text-align:center; padding-top:10px;">
     <asp:Label ID="_errorArticleIdLbl" CssClass="errorLabel" runat="server"></asp:Label>
   </div>
  </asp:Panel>
  <!-- / No Article Selected View -->
  <!-- Article View -->
  <asp:Panel ID="_articlePanel" runat="server"> 
   <!-- Article -->
   <asp:Repeater ID="_articleRepeater" runat="server" DataSourceID="_articleDS" OnItemCreated="_articleRepeater_ItemCreated">
    <ItemTemplate>
      <div style="text-align:center; border-width:0px;" class="article_title"><b><%# DataBinder.Eval(Container.DataItem, "title")%></b></div>
      <b><%= Resources.Resources.PostedBy %>&nbsp;<%# DataBinder.Eval(Container.DataItem, "publisher") %>&nbsp;<%= Resources.Resources.On %>&nbsp;<%# DataBinder.Eval(Container.DataItem, "published", "{0:dd MMMM yyyy HH:mm}")%></b><div>
      <b><%= Resources.Resources.Rating %>:</b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "rating", "{0:0.00}")%></div>
      <div>
        <%# DataBinder.Eval(Container.DataItem, "content")%>
      </div>
    </ItemTemplate>
   </asp:Repeater>
   <tasp:TBAccessDataSource ID="_articleDS" runat="server" 
             SelectCommand="SELECT A.[ID] as articleID,
                                   A.[authorId] as authorId, 
                                   A.[published] as published, 
                                   A.[allowComments] as allowComments, 
                                   A.[title] as title, 
                                   A.[content] as content,
                                   A.[rating] as rating,
                                   P.[names] as publisher
                            FROM [Articles] A, [Authors] P
                            WHERE A.[authorId] = P.[ID] AND A.[ID]=@articleID" OnInit="_articleDS_Init">
        <SelectParameters>
            <asp:Parameter Name="articleID" Type="Int64" />
        </SelectParameters>
   </tasp:TBAccessDataSource>
   <!-- / Article -->
   <!-- Comments -->
   <asp:UpdatePanel ID="_showHideCommentsUP" runat="server">
     <ContentTemplate>
       <asp:Panel ID="_articleFooterPanel" runat="server" CssClass="article_footer">
         <asp:LinkButton ID="_showCommentsLnkBtn" CausesValidation="false" runat="server" OnClick="_showCommentsLnkBtn_Click" CssClass="article_link" /><asp:LinkButton ID="_hideCommentsLnkBtn" CausesValidation="false" runat="server" OnClick="_hideCommentsLnkBtn_Click" CssClass="article_link" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<cc1:rsshyperlink id="_rssHL" runat="server" includeusername="False" CssClass="subMenu_link" OnLoad="_rssHL_Load"></cc1:rsshyperlink>
       </asp:Panel>
       <div style="margin-top:15px;"></div>
       <asp:Panel ID="_commentsTitlePanel" runat="server">
         <div class="blogSubTitle" style="font-size: 18px;">&nbsp;<%= Resources.Resources.Comments %>:</div>
         <div class="divLine" style="margin-top:3px; margin-bottom:5px;"></div>
         <asp:PlaceHolder ID="_commentsAdditionalInfoPH" runat="server"></asp:PlaceHolder>
       </asp:Panel>
       <asp:Repeater ID="_commentsRepeater" runat="server" DataSourceID="_commentsDS" 
        OnItemCreated="_commentsRepeater_ItemCreated" OnPreRender="_commentsRepeater_PreRender">
         <ItemTemplate>
           <div class="commentTitle">
             <asp:Image ID="_flagImage" runat="server" />&nbsp;<%= Resources.Resources.PostedBy %>&nbsp;<%# DataBinder.Eval(Container.DataItem, "names")%>&nbsp;<%= Resources.Resources.On %>&nbsp;<%# DataBinder.Eval(Container.DataItem, "published", "{0:dd MMMM yyyy HH:mm}")%>&nbsp;&nbsp;&nbsp;<%= Resources.Resources.Rating %>:&nbsp;<%# GetRating(DataBinder.Eval(Container.DataItem, "rating")) %></div>
           <div>
             <%# DataBinder.Eval(Container.DataItem, "comment")%>
           </div>
         </ItemTemplate>
       </asp:Repeater>
       <tasp:TBAccessDataSource ID="_commentsDS" runat="server" 
          SelectCommand="SELECT [ID], 
                                [articleId], 
                                [names], 
                                [email], 
                                [website], 
                                [comment], 
                                [published],
                                [country],
                                [rating]
                         FROM [Comments]
                         WHERE [articleId]=@articleId
                         ORDER BY [published] DESC" OnInit="_commentsDS_Init">
            <SelectParameters>
                <asp:Parameter Name="articleId" Type="Int64" />
            </SelectParameters>
       </tasp:TBAccessDataSource>
     </ContentTemplate>
    </asp:UpdatePanel>
   <!-- / Comments -->
   <div style="margin-top:15px;"></div>
   <!-- Add New Comment -->
   <asp:Panel ID="_addCommentPanel" runat="server">
    <div class="blogSubTitle" style="font-size: 18px;">
      &nbsp;<%= Resources.Resources.AddNewComment %>:
      <div class="divLine" style="margin-top:3px;"></div>
    </div>
    <div style=" width: 400px; text-align:center;">
     <controls:CommentsControl ID="_commentsControl"
          FlagsPath="~/images/flags/" 
          JScriptFlagsPath="./images/flags/" runat="server" />
      
        <div style="padding-top:5px; padding-bottom:5px;">
         <asp:Label ID="_resultLbl" CssClass="errorLabel" runat="server" />
        </div>
        <div>
         <asp:Button ID="_addButton" runat="server" OnClick="_addButton_Click"  OnClientClick="ConfirmAdd()"/>
        </div>  
    </div>
   </asp:Panel>
   <!-- / Add New Comment -->
  </asp:Panel> 
  <!-- / Article View -->
    <input type="hidden" id="txtHidData" runat="server" value="true" />
</asp:Content>
