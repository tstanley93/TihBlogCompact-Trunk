<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminFileManager.aspx.cs" Inherits="TihBlogCompact.Admin.adminFileManager" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div>
    <%= Resources.Resources.ArchiveFolder %>:&nbsp;<%= ConfigurationManager.AppSettings["filesPath"]%>
  </div>
  <div class="subMenu">
    <div>
      <b><%= Resources.Resources.UploadFile %>:</b>
    </div>
    <asp:FileUpload ID="_fileFU" runat="server" />
    <div>
      <asp:Label ID="_uploadResultLbl" runat="server" CssClass="errorLabel"></asp:Label>
    </div>
    <asp:Button ID="_uploadFileBtn" runat="server" OnClick="_uploadFileBtn_Click" />
  </div>
  <div style="border-width:0px;" class="article_title">
    <%= Resources.Resources.FileManager %>
  </div>
  <div style="margin-top:15px;">
   <asp:UpdatePanel ID="_filesUP" runat="server">
    <ContentTemplate>
      <div>
        <span class="errorLabel"><%= Resources.Resources.LinksForFilePreview%></span>
      </div>
      <asp:GridView ID="_filesGV" runat="server" SkinID="AdminGridSkin" AutoGenerateColumns="false" AllowSorting="false" AllowPaging="false"
        DataKeyNames="FullName" OnRowCommand="_filesGV_RowCommand" OnRowDeleting="_filesGV_RowDeleting" EmptyDataText="Empty">
        <Columns>
           <asp:TemplateField HeaderText="">
            <ItemTemplate>
              <asp:LinkButton ID="_deleteLnkBtn" runat="server" CommandName="Delete" Text="Delete" CssClass="controlBtn_link"
                   OnClientClick="return confirm('Are you sure you want to delete this file?');"
                   CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FullName") %>'>
              </asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
              <asp:HyperLink ID="_viewImageHL" CssClass="controlBtn_link"
               runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
               NavigateUrl='<%# GetFileURL(DataBinder.Eval(Container.DataItem, "Name")) %>'>"></asp:HyperLink> 
            </ItemTemplate>
           </asp:TemplateField>
           <asp:BoundField DataField="LastWriteTime" HeaderText="Last Write Time" />
           <asp:BoundField DataField="Length" HeaderText="File Size"
		        ItemStyle-HorizontalAlign="Right" 
		        DataFormatString="{0:#,### bytes}" />
        </Columns>
      </asp:GridView>
    </ContentTemplate> 
   </asp:UpdatePanel>
  </div>
</asp:Content>
