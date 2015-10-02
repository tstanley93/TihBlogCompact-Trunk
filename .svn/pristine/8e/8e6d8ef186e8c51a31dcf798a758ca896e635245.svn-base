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
    public partial class adminAddCategory : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            _addButton.Text = Resources.Resources.Add;
        }

        protected void _addButton_Click(object sender, EventArgs e)
        {
            string categoryName;

            try
            {
                categoryName = _categoryNameTB.Text;

                // CategoryNameExist

                if (Articles.ArticleCategoryExist(categoryName))
                {
                    _resultLbl.Text = Resources.Resources.CategoryNameExist;
                    return;
                }

                Articles.AddNewArticleCategory(categoryName, false);

                _resultLbl.Text = Resources.Resources.CategoryAdded + "!";
            }
            catch (Exception)
            {
                _resultLbl.Text = Resources.Resources.UnknownError;
            }
        }

        #endregion
    }
}
