<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="commentsControl.ascx.cs" Inherits="TihBlogCompact.Controls.commentsControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<table>
 <tbody>
  <tr>
   <td>
     <%= Resources.Resources.Name %>*:
   </td>
   <td>
     <asp:TextBox runat="Server" ID="_nameTB" TabIndex="1" Width="250px" ValidationGroup="AddComment" />
     <asp:RequiredFieldValidator ID="_nameRFV" runat="server" Display="Dynamic" ControlToValidate="_nameTB">
        <br />
        *<%= Resources.Resources.EnterName %>!
     </asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="_nameREV" runat="server" Display="Dynamic" ControlToValidate="_nameTB" ValidationExpression="[A-Za-z_\s.]+" >
        <br />
        *<%= Resources.Resources.EnterValidName %>!
     </asp:RegularExpressionValidator>
     <asp:RegularExpressionValidator ID="_nameMaxLen" runat="server" Display="dynamic" ControlToValidate="_nameTB" ValidationExpression="^([\S\s]{0,50})$">
        <br />
        *<%= Resources.Resources.EnterLessThan %>35&nbsp;<%= Resources.Resources.Characters %>!
     </asp:RegularExpressionValidator>
   </td>
   <td>
     &nbsp;&nbsp;&nbsp;<%= Resources.Resources.Rating %>:
   </td>
   <td>
     <asp:DropDownList ID="_ratingDDL" runat="server">
       <asp:ListItem Text="[not set]" Value="-1" Selected="True"></asp:ListItem>
       <asp:ListItem Text="10 [Highest]" Value="10"></asp:ListItem>
       <asp:ListItem Text="9" Value="9"></asp:ListItem>
       <asp:ListItem Text="8" Value="8"></asp:ListItem>
       <asp:ListItem Text="7" Value="7"></asp:ListItem>
       <asp:ListItem Text="6" Value="6"></asp:ListItem>
       <asp:ListItem Text="5" Value="5"></asp:ListItem>
       <asp:ListItem Text="4" Value="4"></asp:ListItem>
       <asp:ListItem Text="3" Value="3"></asp:ListItem>
       <asp:ListItem Text="2" Value="2"></asp:ListItem>
       <asp:ListItem Text="1 [Lowest]" Value="1"></asp:ListItem>
     </asp:DropDownList>
   </td>
  </tr>
  <tr>
   <td>
     <%= Resources.Resources.Email %>*:
   </td>
   <td>
     <asp:TextBox runat="Server" ID="_emailTB" TabIndex="2" Width="250px" ValidationGroup="AddComment" />
     <asp:RequiredFieldValidator ID="_emailRFV" runat="server" Display="Dynamic" ControlToValidate="_emailTB">
        <br />
        *<%= Resources.Resources.EnterEmail %>!
     </asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="_emailREV" runat="server" Display="Dynamic" ControlToValidate="_emailTB" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" >
        <br />
        *<%= Resources.Resources.EnterValidEmail %>!
     </asp:RegularExpressionValidator>
     <asp:RegularExpressionValidator ID="_mailMaxLen" runat="server" Display="dynamic" ControlToValidate="_emailTB" ValidationExpression="^([\S\s]{0,35})$">
        <br />
        *<%= Resources.Resources.EnterLessThan %>35&nbsp;<%= Resources.Resources.Characters %>
     </asp:RegularExpressionValidator>
   </td>
   <td colspan="2">
   </td>
  </tr>
  <tr>
   <td>
     <%= Resources.Resources.Website %>:
   </td>
   <td>
     <asp:TextBox runat="Server" ID="_websiteTB" TabIndex="3" Width="250px" ValidationGroup="AddComment" />
     <asp:RegularExpressionValidator ID="_websiteREV" runat="Server" ControlToValidate="_websiteTB" ValidationExpression="(http://|https://|)([\w-]+\.)+[\w-]+(/[\w- ./?%&=;~]*)?" Display="Dynamic" ValidationGroup="AddComment">
      <br />
      <%= Resources.Resources.EnterValidURL %>
     </asp:RegularExpressionValidator>
   </td>
   <td colspan="2">
   </td>
  </tr>
  <tr>
   <td>
     <%= Resources.Resources.Country %>:
   </td>
   <td>
     <asp:DropDownList runat="server" ID="_countriesDdl" ValidationGroup="AddComment" />&nbsp;<asp:Image runat="server" ID="_imgFlag" AlternateText="Country flag" Width="16" Height="11" />
   </td>
   <td colspan="2">
   </td>
  </tr>
  <tr>
   <td><%= Resources.Resources.Comment %>*:</td>
   <td colspan="3">
   </td>
  </tr>
  <tr>
   <td colspan="4">
     <FCKeditorV2:FCKeditor ID="_fckEditor" Width="350px" Height="150px" ToolbarSet="TihBlog" ToolbarCanCollapse="false" runat="server" BasePath="~/editor/" />
   </td>
  </tr>
 </tbody>
</table>

<script type="text/javascript">

    function SetFlag(img, val)
    {
      if (img != null)
      {
        if (val.length > 0)
            img.src = "<%= JScriptFlagsPath %>" + val + ".png";
        else
            img.src = "<%= JScriptFlagsPath %>" + "pixel.gif";
      }
    }

</script>