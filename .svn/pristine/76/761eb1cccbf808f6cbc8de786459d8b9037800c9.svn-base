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

namespace TihBlogCompact
{
    public partial class adminAddLink : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            _addButton.Text = Resources.Resources.Add;
        }

        protected void _addButton_Click(object sender, EventArgs e)
        {
            string url, text;

            try
            {
                url = _urlTB.Text;
                text = _textTB.Text;

                Links.AddNew(url, text);

                _resultLbl.Text = Resources.Resources.LinkAdded + "!";
            }
            catch (Exception)
            {
                _resultLbl.Text = Resources.Resources.UnknownError;
            }
        }

        #endregion
    }
}
