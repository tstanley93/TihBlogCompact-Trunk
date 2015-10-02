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
using TihBlogCompact.Business;

namespace TihBlogCompact.Admin
{
    public partial class adminMain : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

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

        public string GetCommentsCount()
        {
            return Articles.GetTotalCommentsCount();
        }

        public string GetArticlesCount()
        {
            return Articles.GetTotalArticlesCount();
        }

        public string GetAuthorsCount()
        {
            return TihBlogCompact.Business.Authors.GetTotalCount();
        }

        public string GetLastPublishedCOmment()
        {
            return Articles.GetLastComment();
        }

        #endregion
    }
}
