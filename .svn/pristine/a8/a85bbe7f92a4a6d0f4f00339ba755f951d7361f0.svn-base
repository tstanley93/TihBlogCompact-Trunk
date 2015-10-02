<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminAddCategory.aspx.cs" Inherits="TihBlogCompact.adminAddCategory" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div style="border-width:0px;" class="article_title">
   <%= Resources.Resources.Categories %>&nbsp;&gt;&nbsp;<%= Resources.Resources.AddNew %>:
  </div>
  <div style="margin-top: 10px;">
   <table>
    <tr>
     <td>
       <%= Resources.Resources.CategoryName %>:
     </td>
     <td>
       <asp:TextBox ID="_categoryNameTB" runat="server" Width="200px"></asp:TextBox>
       <asp:RequiredFieldValidator ID="_categoryNameRFV" runat="server" Display="Dynamic" ControlToValidate="_categoryNameTB">
        *
       </asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="_categoryNameMaxLen" 
          runat="server" Display="dynamic" 
          ControlToValidate="_categoryNameTB" 
          ValidationExpression="^([\S\s]{0,45})$">
            <br />
            *45 characters max
       </asp:RegularExpressionValidator>
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
