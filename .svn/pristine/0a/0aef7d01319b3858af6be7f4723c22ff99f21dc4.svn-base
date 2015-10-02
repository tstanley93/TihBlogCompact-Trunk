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
    public partial class adminChangePassword : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _changePassBtn.Text = Resources.Resources.ChangePassword;
            }
            catch (Exception)
            { 
            }
        }

        protected void _changePassBtn_Click(object sender, EventArgs e)
        {
            string username, oldPassword, newPassword;

            try
            {
                username = GetUserName();
                oldPassword = _currentPasswordTB.Text;
                newPassword = _newPasswordTB.Text;
                
                // check if the current password is correct 
                if (!UserManagement.IsLoginValid(username, oldPassword))
                {
                    _resultLbl.Text = Resources.Resources.IncorrectPassword;
                    return;
                }

                // change password
                UserManagement.ChangePassword(username, newPassword);
                _resultLbl.Text = Resources.Resources.PasswordChanged + "!";
            }
            catch (Exception)
            {
                _resultLbl.Text = Resources.Resources.UnknownError + "!";
            }
        }

        #endregion

        #region Public Methods

        public string GetUserName()
        {
            string result = "";

            try
            {
                if (Session[Constants.Session.USERNAME] != null)
                    result = Session[Constants.Session.USERNAME].ToString();
            }
            catch (Exception)
            {
            }

            return result;
        }

        #endregion
    }
}
