<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminAddLink.aspx.cs" Inherits="TihBlogCompact.adminAddLink" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div style="border-width:0px;" class="article_title">
   <%= Resources.Resources.Links %>&nbsp;&gt;&nbsp;<%= Resources.Resources.AddNew %>:
  </div>
  <div style="margin-top: 10px;">
   <table>
    <tr>
     <td>
       <%= Resources.Resources.URL %>:
     </td>
     <td>
       <asp:TextBox ID="_urlTB" runat="server" Width="200px"></asp:TextBox>
       <asp:RequiredFieldValidator ID="_urlRFV" runat="server" Display="Dynamic" ControlToValidate="_urlTB">
        *
       </asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="_categoryNameMaxLen" 
          runat="server" Display="dynamic" 
          ControlToValidate="_urlTB" 
          ValidationExpression="^([\S\s]{0,200})$">
            <br />
            *200 characters max
       </asp:RegularExpressionValidator>
     </td>
    </tr>
    <tr>
     <td>
       <%= Resources.Resources.Text %>:
     </td>
     <td>
       <asp:TextBox ID="_textTB" runat="server" Width="200px"></asp:TextBox>
       <asp:RequiredFieldValidator ID="_textRFV" runat="server" Display="Dynamic" ControlToValidate="_textTB">
        *
       </asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="_textREV" 
          runat="server" Display="dynamic" 
          ControlToValidate="_textTB" 
          ValidationExpression="^([\S\s]{0,200})$">
            <br />
            *200 characters max
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
