<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminSettings.aspx.cs" Inherits="TihBlogCompact.adminSettings" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">

  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div style="border-width:0px;" class="article_title">
    <%= Resources.Resources.Settings %>
  </div>
  <table>
   <tr>
    <td>
      <%= Resources.Resources.PageTitleTag %>:
    </td>
    <td>
      <asp:TextBox ID="_pageTitleTagTB" runat="server" Width="300px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="_pageTitleTagRFV" runat="server" Display="Dynamic" ControlToValidate="_pageTitleTagTB">
        *
      </asp:RequiredFieldValidator>
    </td>
   </tr>
   <tr>
    <td>
      <%= Resources.Resources.BlogTitle %>:
    </td>
    <td>
      <asp:TextBox ID="_blogTitleTB" runat="server" Width="300px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="_blogTitleRFV" runat="server" Display="Dynamic" ControlToValidate="_blogTitleTB">
        *
      </asp:RequiredFieldValidator>
    </td>
   </tr>
   <tr>
    <td>
      <%= Resources.Resources.BlogSubTitle %>:
    </td>
    <td>
      <asp:TextBox ID="_blogSubTitleTB" runat="server" Width="300px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="_blogSubTitleRFV" runat="server" Display="Dynamic" ControlToValidate="_blogSubTitleTB">
        *
      </asp:RequiredFieldValidator>
    </td>
   </tr>
   <tr>
    <td>
      <%= Resources.Resources.CryptKey %>:
    </td>
    <td>
      <asp:TextBox ID="_cryptKeyTB" runat="server" Width="300px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="_cryptKeyRFV" runat="server" Display="Dynamic" ControlToValidate="_cryptKeyTB">
        *
      </asp:RequiredFieldValidator>
    </td>
   </tr>
   <tr>
    <td>
      <%= Resources.Resources.CommentsToShow %>:
    </td>
    <td>
      <asp:TextBox ID="_commentsToShowTB" runat="server" Width="30px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="_commentsToShowRFV" runat="server" Display="Dynamic" ControlToValidate="_commentsToShowTB">
        *
      </asp:RequiredFieldValidator>
      <asp:CompareValidator ID="_commentsToShowCV" runat="server" ControlToValidate="_commentsToShowTB"
         Operator="GreaterThan" Type="Integer" ValueToCompare="0">
        Must be a valid number(Greater than 0).
      </asp:CompareValidator>
    </td>
   </tr>
   <tr>
    <td>
      <%= Resources.Resources.ArticlesPerPage %>:
    </td>
    <td>
      <asp:TextBox ID="_articlesPerPageTB" runat="server" Width="30px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="_articlesPerPageRFV" runat="server" Display="Dynamic" ControlToValidate="_articlesPerPageTB">
        *
      </asp:RequiredFieldValidator>
      <asp:CompareValidator ID="_articlesPerPageCV" runat="server" ControlToValidate="_articlesPerPageTB"
         Operator="GreaterThan" Type="Integer" ValueToCompare="0">
        Must be a valid number(Greater than 0).
      </asp:CompareValidator>
    </td>
   </tr>
   <tr>
    <td>
      <%= Resources.Resources.TopArticlesCount %>:
    </td>
    <td>
      <asp:TextBox ID="_topArticlesCountTB" runat="server" Width="30px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="_topArticlesCountRFV" runat="server" Display="Dynamic" ControlToValidate="_topArticlesCountTB">
        *
      </asp:RequiredFieldValidator>
      <asp:CompareValidator ID="_topArticlesCountCV" runat="server" ControlToValidate="_topArticlesCountTB"
         Operator="GreaterThan" Type="Integer" ValueToCompare="0">
        Must be a valid number(Greater than 0).
      </asp:CompareValidator>
    </td>
   </tr>
   <tr>
     <td>
       <%= Resources.Resources.Theme %>:
     </td>
     <td>
       <asp:DropDownList ID="_themesDDL" runat="server" OnInit="_themesDDL_Init" Width="220px" />
     </td>
   </tr>
   <tr>
     <td>
       <%= Resources.Resources.Language %>:
     </td>
     <td>
       <asp:DropDownList ID="_languagesDDL" runat="server" Width="220px">
        <asp:ListItem Text="Auto" Value=""></asp:ListItem>
        <asp:ListItem Text="English" Value="en-US"></asp:ListItem>
        <asp:ListItem Text="Български" Value="bg-BG"></asp:ListItem>
        <asp:ListItem Text="Deutsch" Value="de-DE"></asp:ListItem>
        <asp:ListItem Text="Français" Value="fr-FR"></asp:ListItem>
        <asp:ListItem Text="Español" Value="es-ES"></asp:ListItem>
       </asp:DropDownList>
     </td>
   </tr>
   <tr>
    <td colspan="2" style="text-align:center;">
      <asp:Label ID="_resultLbl" CssClass="errorLabel" runat="server" />
    </td>
   </tr>
   <tr>
    <td colspan="2" style="text-align:center;">
      <asp:Button ID="_updateButton" runat="server" OnClick="_updateButton_Click" />
    </td>
   </tr> 
  </table>
  
  </asp:Content>
