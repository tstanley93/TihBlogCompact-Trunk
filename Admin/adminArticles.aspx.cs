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
using System.Collections.Generic;
using System.Text;
using TihBlogCompact.Controls;
using TihBlogCompact.Business;

namespace TihBlogCompact.Admin
{
    public partial class adminArticles : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void _articlesGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            object obj;

            try
            {
                obj = e.Keys[0];
                if (obj != null)
                {
                    // delete all comments for the article, we deleteing
                    // in DataSource DeleteComment cannot be "DELETE FROM []; DELETE FROM []"
                    // exception: Characters found after end of SQL statement
                    // That's why here(on Row Deleting, we delete comments separate)
                    Articles.DeleteArticlesComments(obj.ToString());
                }
            }
            catch (Exception)
            { 
            }
        }

        protected void _articlesGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string articleId;
            categoriesControl categories;
            bool allCategories;
            List<string> selectedIds = null;

            try
            {
                articleId = e.Keys[0].ToString();

                categories = _articlesGV.Rows[e.RowIndex].FindControl("_categoriesControl") as categoriesControl;

                if (categories != null)
                { 
                    allCategories = categories.AllCategoriesAreSelected();
                    if (!allCategories)
                        selectedIds = categories.GetSelectedCategories();

                    Articles.UpdateArticles(allCategories, selectedIds, articleId);
                }
            }
            catch (Exception)
            { 
            }
        }

        #endregion

        #region Public Methods

        public string GetCategoriesForArticle(object aId)
        {
            List<Dictionary<string, string>> categories;
            Dictionary<string, string> dict;
            StringBuilder result = new StringBuilder(250);

            try
            {
                if (aId != null)
                {
                    categories = Articles.GetArticlesCategories(aId.ToString());

                    if (categories != null)
                    {
                        result.Append("<div style='width:100%;text-align:left;' >");

                        // if article's in all categories
                        if (categories.Count == 1 && categories[0]["id"].Equals("1"))
                        {
                            result.Append(Resources.Resources.AllCategories);
                        }
                        else
                        {
                            for (int i = 0; i < categories.Count; ++i)
                            {
                                dict = categories[i];

                                result.Append("<br />");

                                result.Append("<input type='checkbox' disabled='disabled' checked='checked'>" + dict["name"] + "</input>");
                            }
                        }

                        result.Append("</div>");
                    }
                }
            }
            catch (Exception)
            { 
            }

            return result.ToString();
        }

        #endregion
    }
}
