using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TihBlogCompact.Business;
using TihBlogCompact.Core;

namespace TihBlogCompact.Admin
{
    public partial class login : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            SetFocus(_usernameTB);
            try
            {
                _loginBtn.Text = Resources.Resources.Login;
            }
            catch (Exception)
            {
            }
        }

        protected void _loginBtn_Click(object sender, EventArgs e)
        {
            string username, password;

            try
            {
                username = _usernameTB.Text;
                password = _passwordTB.Text;

                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                    throw new Exception();

                // checks username/password
                if (UserManagement.IsLoginValid(username, password))
                {
                    // attemt to login was successful
                    // set user is logged-in
                    Session.Add(Constants.Session.USERNAME, username);

                    // redirects to admin's main page
                    Response.Redirect("~/Admin/adminMain.aspx");
                }
                else
                { 
                    // unsuccessful login
                    _resultLbl.Text = Resources.Resources.UnsuccessfulLogin;
                }
            }
            catch (Exception)
            {
                _resultLbl.Text = Resources.Resources.UnsuccessfulLogin;
            }
        }

        #endregion
    }
}
