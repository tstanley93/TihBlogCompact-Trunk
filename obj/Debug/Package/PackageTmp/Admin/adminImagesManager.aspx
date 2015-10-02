<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminImagesManager.aspx.cs" Inherits="TihBlogCompact.Admin.adminImagesManager" %>


<asp:Content ID="_headContent" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
    <script type="text/javascript" src='<%= ResolveUrl("~/script/imagesViewer.js") %>'></script>
    <link rel='stylesheet' type='text/css' href='<%= ResolveUrl("~/style/imagesViewer.css") %>' />
</asp:Content>

<asp:Content ID="_adminContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div>
    <%= Resources.Resources.ImagesFolder %>:&nbsp;<%= ConfigurationManager.AppSettings["imagesPath"]%>
  </div>
  <div class="subMenu">
    <div>
      <b><%= Resources.Resources.UploadImage %>:</b>
    </div>
    
       <asp:FileUpload ID="_imageFU" runat="server" />
       <asp:RegularExpressionValidator
            ID="_fileUploadREV" runat="server"
            ErrorMessage="Upload Jpegs, Gifs and Png only."
            ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF|.png|.PNG)$"
            ControlToValidate="_imageFU">
       </asp:RegularExpressionValidator>
       <div>
         <asp:Label ID="_uploadResultLbl" runat="server" CssClass="errorLabel"></asp:Label>
       </div>
       <asp:Button ID="_uploadImageBtn" runat="server" OnClick="_uploadImageBtn_Click" />

      
  </div>
  <div style="border-width:0px;" class="article_title">
    <%= Resources.Resources.ImagesManager %>
  </div>
  <div style="margin-top:15px;">
   <asp:UpdatePanel ID="_imagesUP" runat="server">
    <ContentTemplate>
      <div>
        <span class="errorLabel"><%= Resources.Resources.LinksForImagePreview %></span>
      </div>
      <asp:GridView ID="_imagesGV" runat="server" SkinID="AdminGridSkin" AutoGenerateColumns="false" AllowSorting="false" AllowPaging="false"
        DataKeyNames="FullName" OnRowCommand="_imagesGV_RowCommand" OnRowDeleting="_imagesGV_RowDeleting" EmptyDataText="Empty">
        <Columns>
           <asp:TemplateField HeaderText="">
            <ItemTemplate>
              <asp:LinkButton ID="_deleteLnkBtn" runat="server" CommandName="Delete" Text="Delete" CssClass="controlBtn_link"
                   OnClientClick="return confirm('Are you sure you want to delete this image?');"
                   CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FullName") %>'>
              </asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Image">
            <ItemTemplate>
              <asp:HyperLink ID="_viewImageHL" CssClass="controlBtn_link"
               rel="lightbox" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
               NavigateUrl='<%# GetImageURL(DataBinder.Eval(Container.DataItem, "Name")) %>'>"></asp:HyperLink> 
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
