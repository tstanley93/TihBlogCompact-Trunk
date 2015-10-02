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
using Microsoft.Web.UI;
using TihBlogCompact.Business;

namespace TihBlogCompact
{
    public partial class adminCategories : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void _categoriesGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string newCategoryName, id;

            try
            {
                id = e.Keys[0].ToString();
                newCategoryName = e.NewValues["categoryName"].ToString();

                if (string.IsNullOrEmpty(newCategoryName) || string.IsNullOrEmpty(id))
                    throw new Exception("Invalid arguments!");

                // check is new category name, already exists to another gorup
                if (Articles.ArticleCategoryExist(newCategoryName, id))
                {
                    e.Cancel = true;
                    ScriptManager.RegisterStartupScript(Page, GetType(), "unknownError", "alert('" + Resources.Resources.CategoryNameExist + "!');", true);
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
                ScriptManager.RegisterStartupScript(Page, GetType(), "unknownError", "alert('" + Resources.Resources.UnknownError + "!');", true);
            }
        }

        protected void _categoriesGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id;

            try
            {
                id = e.Keys[0].ToString();

                // check in category to delete contains article
                if (Articles.ArticlesExistsInCategory(id))
                {
                    e.Cancel = true;
                    ScriptManager.RegisterStartupScript(Page, GetType(), "unknownError", "alert('" + Resources.Resources.ArticlesExistOnCategory + "!');", true);
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
                ScriptManager.RegisterStartupScript(Page, GetType(), "unknownError", "alert('" + Resources.Resources.UnknownError + "!');", true);
            }
        }

        #endregion
    }
}
