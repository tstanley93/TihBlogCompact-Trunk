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
using TihBlogCompact.Core;

namespace TihBlogCompact.Admin
{
    public partial class AdminMainMaster : System.Web.UI.MasterPage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            bool loggedIn = false;

            try
            {
                _logoutBtn.Text = Resources.Resources.Logout;

                loggedIn = IsLoggedIn();

                // check if the user is logged in
                // if not redirects to login page
                if (!loggedIn)
                    Response.Redirect("~/admin/login.aspx");
                
            }
            catch (Exception)
            {
                if (!loggedIn)
                    Response.Redirect("~/Admin/login.aspx");
            }
        }

        protected void _logoutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // log out from admin system
                Session.Abandon();

                Response.Redirect("~/Admin/login.aspx");
            }
            catch (Exception)
            { 
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

        #region Private Methods

        private bool IsLoggedIn()
        {
            bool result = false;
            string username;

            try
            {
                username = Session[Constants.Session.USERNAME] as string;

                result = !String.IsNullOrEmpty(username);
            }
            catch (Exception)
            {
            }

            return result;
        }

        #endregion      
    }
}
