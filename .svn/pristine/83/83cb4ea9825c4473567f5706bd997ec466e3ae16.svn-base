<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminAddArticle.aspx.cs" Inherits="TihBlogCompact.Admin.adminAddArticle" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/Controls/categoriesControl.ascx" TagName="CategoriesControl" TagPrefix="controls" %>

<asp:Content ID="_headContent" ContentPlaceHolderID="_headContentPlaceHolder" runat="server">
    <script type="text/javascript" src='<%= ResolveUrl("~/script/imagesViewer.js") %>'></script>
    <link rel='stylesheet' type='text/css' href='<%= ResolveUrl("~/style/imagesViewer.css") %>' />
</asp:Content>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <script type="text/javascript" src='<%= ResolveUrl("~/script/BrowserDetect.js") %>'></script>
  <script language="javascript" type="text/javascript">
    function CheckArticleTitle(titleId)
    {
        if (BrowserDetect.browser == "Explorer" /* && BrowserDetect.version >= 6 */)
        {
            title = this.document.getElementById(titleId);
            
            // checks if title is entered
            if (title != null && title.value != null && title.value.length > 0)
                return true;
        
            alert("Please, Enter an Article's Title");
            return false;
        }
        else
        {
            title = $get(titleId);
            
            // checks if title is entered
            if (title != null && title.value != null && title.value.length > 0)
                return true;
            
            alert("Please, Enter an Article's Title");    
            return false;
        }
    }
  </script>
  
  <script language="javascript" type="text/javascript">
  
    function InsertImageToEditor(imagePath, ddlId, editorId)
    {
        // Get the editor instance that we want to interact with.
        var oEditor = FCKeditorAPI.GetInstance(editorId);
        
        if (oEditor != null)
        {
           imagesDropDown = document.getElementById(ddlId);
       
           if (imagesDropDown)
           {
              var imageSrc = '<img alt="" src="' + imagePath + imagesDropDown.value + '" />';
              oEditor.InsertHtml(imageSrc);
           }
        }
        
        return false;
    }
    
    function OnChangeSelectedPicture(ddlId, imgId, imagesPath)
    {
        imagesDropDown = document.getElementById(ddlId);
        imagesView = document.getElementById(imgId);
    
        if (imagesDropDown != null && imagesView != null)
        {
            imagesView.pathname = imagesPath + imagesDropDown.value;
        }
    }
    
    function InsertFileToEditor(filePath, ddlId, editorId)
    {
        // Get the editor instance that we want to interact with.
        var oEditor = FCKeditorAPI.GetInstance(editorId);
        
        if (oEditor != null)
        {
           filesDropDown = document.getElementById(ddlId);
       
           if (filesDropDown)
           {
              var fileSrc = '<a href="' + filePath + filesDropDown.value + '">' + filesDropDown.value + '</a>';
              oEditor.InsertHtml(fileSrc);
           }
        }
        
        return false;
    }
    
  </script>
  <div style="border-width:0px;" class="article_title">
   <%= Resources.Resources.Articles %>&nbsp;&gt;&nbsp;<%= Resources.Resources.AddNew %>:
  </div>
  <div style="margin-top: 10px;">
   <table>
    <tr>
     <td>
       <%= Resources.Resources.Title %>:
     </td>
     <td>
       <asp:TextBox ID="_titleTB" runat="server" Width="650px"></asp:TextBox>
     </td>
    </tr>
    <tr>
     <td colspan="2">
       <%= Resources.Resources.Article %>:
     </td>
    </tr>
    <tr>
     <td colspan="2">
       <table cellpadding="2px" style="background-color:#EFEFDE; width:100%; border:1px solid #696969;">
         <tr>
           <td>
             <%= Resources.Resources.Images %>:
           </td>
           <td>
             <asp:DropDownList ID="_picturesDDL" runat="server" OnInit="_picturesDDL_Init" Width="220px" />&nbsp;<asp:HyperLink ID="_viewImageHL"
                   CssClass="controlBtn_link" rel="lightbox" runat="server"></asp:HyperLink>
           </td>
           <td>
             <asp:Button ID="_insertImageBtn" runat="server" />
           </td>
         </tr>
         <tr>
           <td>
             <%= Resources.Resources.Files %>:
           </td>
           <td>
             <asp:DropDownList ID="_filesDDL" runat="server" OnInit="_filesDDL_Init" Width="220px" />
           </td>
           <td>
             <asp:Button ID="_insertFileBtn" runat="server" />
           </td>
         </tr>
        </table>
       <FCKeditorV2:FCKeditor ID="_fckEditor" Width="800px" Height="500px" 
            ToolbarSet="TihBlogAdmin" ToolbarCanCollapse="false" runat="server" 
            BasePath="~/editor/" />
     </td>
    </tr>
    <tr>
     <td colspan="2">
      <asp:CheckBox ID="_commentsAreOffChB" runat="server" Checked="false" />
     </td>
    </tr>
    <tr>
     <td>
      <%= Resources.Resources.Categories %>:
      <controls:CategoriesControl ID="_categoriesControl" runat="server" />
     </td>
     <td>
     </td>
    </tr>
    <tr>
     <td colspan="2" style="text-align:center;">
       <asp:Label ID="_resultLbl" CssClass="errorLabel" runat="server" />
     </td>
    </tr>
    <tr>
     <td colspan="2" style="text-align:center;">
       <asp:Button ID="_addButton" runat="server" OnClick="_addButton_Click" />
     </td>
    </tr>
   </table>
  </div>
</asp:Content>
