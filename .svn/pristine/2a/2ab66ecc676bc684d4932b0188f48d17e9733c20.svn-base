<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminChangePassword.aspx.cs" Inherits="TihBlogCompact.Admin.adminChangePassword" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div style="border-width:0px;" class="article_title">
    <%= Resources.Resources.ChangePassword %>
  </div>
  <table>
    <tr>
     <td>
       <%= Resources.Resources.CurrentPassword %>: 
     </td>
     <td>
       <asp:TextBox ID="_currentPasswordTB" runat="server" Width="150px" TextMode="Password" />
       <asp:RequiredFieldValidator ID="_passwordRFV" runat="server" Display="Dynamic" ControlToValidate="_currentPasswordTB">
          <br />
          *<%= Resources.Resources.EnterPassword %>!
       </asp:RequiredFieldValidator>
     </td>
    </tr>
    <tr>
     <td>
       <%= Resources.Resources.NewPassword %>: 
     </td>
     <td>
       <asp:TextBox ID="_newPasswordTB" runat="server" Width="150px" TextMode="Password" />
       <asp:RequiredFieldValidator ID="_newPasswordRFV" runat="server" Display="Dynamic" ControlToValidate="_newPasswordTB">
          <br />
          *<%= Resources.Resources.EnterNewPassword %>!
       </asp:RequiredFieldValidator>
     </td>
    </tr>
    <tr>
     <td>
       <%= Resources.Resources.ConfirmNewPassword %>: 
     </td>
     <td>
       <asp:TextBox ID="_confirmPasswordTB" runat="server" Width="150px" TextMode="Password" />
       <asp:RequiredFieldValidator ID="_confirmPasswordRFV" runat="server" Display="Dynamic" ControlToValidate="_confirmPasswordTB">
          <br />
          *<%= Resources.Resources.EnterConfirmPassword %>!
       </asp:RequiredFieldValidator>
       <asp:CompareValidator ID="_confirmPasswordCV" runat="server" ControlToValidate="_confirmPasswordTB" ControlToCompare="_newPasswordTB">
        <br />
        <%= Resources.Resources.PasswordsNotMatch %>!
       </asp:CompareValidator> 
     </td>
    </tr>
    <tr>
     <td colspan="2" style="text-align:center;">
       <asp:Label ID="_resultLbl" CssClass="errorLabel" runat="server" />
     </td>
    </tr>
    <tr>
     <td colspan="2" style="text-align:center;">
       <asp:Button ID="_changePassBtn" runat="server" OnClick="_changePassBtn_Click" />
     </td>
    </tr>
  </table>

</asp:Content>
