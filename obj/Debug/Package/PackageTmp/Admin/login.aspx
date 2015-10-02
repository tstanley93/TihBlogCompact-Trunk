﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TihBlogCompact.Admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%= ConfigurationManager.AppSettings["titleTag"]%></title>
</head>
<body>
    <div class="BodyDiv">
        <div>
        <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="33" style="background-color:#474747; border:1px solid #474747;color:#ffffff;">
                    <table width="100%" border="0" cellspacing="5" cellpadding="0">
                      <tr>
                        <td class="p" width="50%">
                        </td>
                        <td width="50%" align="center">Today's date is <%= DateTime.Now.ToLongDateString() %></td>
                      </tr>
                    </table>
                    </td>
                  </tr>
                  <tr>
                    <td>
                        <img src="../images/Arc_Logo_v2.jpg" width="1000" height="199" alt="" />
                    </td>
                  </tr>
                  <tr>
                    <td>
                    </td>
                  </tr>
                </table>
                </td>
              </tr>
            </table>
    </div>
        <form id="_mainForm" runat="server">
          <div class="subMenu">
             <a class="subMenu_link" href='<%= ResolveUrl("~/Default.aspx") %>'><%= Resources.Resources.Home %></a>&nbsp;&nbsp;&nbsp;
                 <a class="simple_link" href='<%= ResolveUrl("http://arcgh.eisconsult.com/") %>'>Arc Home</a>
          </div>
          <div class="areaTitle" style="margin-top:12px;">
             <h2><%= Resources.Resources.Login %></h2>
          </div>
          <div class="areaInner" style="font-size:10px;">
           <table align="center">
            <tr>
             <td>
               <%= Resources.Resources.Username %>:
             </td>
             <td>
               <asp:TextBox ID="_usernameTB" runat="server" Width="150px" />
               <asp:RequiredFieldValidator ID="_usernameRFV" runat="server" Display="Dynamic" ControlToValidate="_usernameTB">
                <br />
                 *<%= Resources.Resources.EnterUserName %>!
               </asp:RequiredFieldValidator>
             </td>
            </tr>
            <tr>
             <td>
               <%= Resources.Resources.Password %>:
             </td>
             <td>
               <asp:TextBox ID="_passwordTB" runat="server" Width="150px" TextMode="Password" />
               <asp:RequiredFieldValidator ID="_passwordRFV" runat="server" Display="Dynamic" ControlToValidate="_passwordTB">
                <br />
                 *<%= Resources.Resources.EnterPassword %>!
               </asp:RequiredFieldValidator>
             </td>
            </tr>
            <tr>
             <td colspan="2">
               <asp:Label ID="_resultLbl" CssClass="errorLabel" runat="server" />
             </td>
            </tr>
            <tr>
             <td colspan="2">
               <asp:Button ID="_loginBtn" runat="server" OnClick="_loginBtn_Click" />
             </td>
            </tr>
           </table>
          </div>
        </form>
        <div id="footer" style=" margin-top: 50px;">
            <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">  
                <tr>
                    <td style="background-color: #EA7125;" height="70px">
                        <h1 style="color: White; margin-left: 15px; font-style: italic;">Achieve with us.</h1>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>
