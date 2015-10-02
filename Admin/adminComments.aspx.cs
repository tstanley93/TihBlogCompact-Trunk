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

namespace TihBlogCompact.Admin
{
    public partial class adminComments : BasePage
    {
        #region Private Members


        private const string _SELECT_ALL_COMMENTS = "SELECT C.[ID] as [ID], " +
                                                            "C.[articleId] as [articleId], " +
                                                            "C.[names] as [names], " +
                                                            "C.[email] as [email], " +
                                                            "C.[website] as [website], " +
                                                            "C.[comment] as [comment], " +
                                                            "C.[published] as [published], " +
                                                            "C.[country] as [country], " +
                                                            "A.[title] as [title] " +
                                                     "FROM [Comments] C " +
                                                     "LEFT JOIN [Articles] A ON C.[articleId] = A.[ID] " +
                                                     "ORDER BY C.[published] DESC";

        private const string _SELECT_COMMENTS_FOR_ARTICLE = "SELECT C.[ID] as [ID], " +
                                                                    "C.[articleId] as [articleId], " +
                                                                    "C.[names] as [names], " +
                                                                    "C.[email] as [email], " +
                                                                    "C.[website] as [website], " +
                                                                    "C.[comment] as [comment], " +
                                                                    "C.[published] as [published], " +
                                                                    "C.[country] as [country], " +
                                                                    "A.[title] as [title] " +
                                                             "FROM [Comments] C " +
                                                             "LEFT JOIN [Articles] A ON C.[articleId] = A.[ID] " +
                                                             "WHERE C.[articleId]=@articleId " +
                                                             "ORDER BY C.[published] DESC";

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _applyFilterBtn.Text = Resources.Resources.ApplyFilter;
                _CommentsGV.EmptyDataText = Resources.Resources.NoComments;
            }
            catch (Exception)
            { 
            }
        }

        protected void _articlesDDL_PreRender(object sender, EventArgs e)
        {
            ListItem listItem;

            try
            {
                listItem = new ListItem();
                listItem.Text = "[" + Resources.Resources.AllArticles + "]";
                listItem.Value = "0";

                if (!_articlesDDL.Items.Contains(listItem))
                    _articlesDDL.Items.Insert(0, listItem);
            }
            catch (Exception)
            {
            }
        }

        protected void _applyFilterBtn_Click(object sender, EventArgs e)
        {
            string buff;
            Int64 articleId;

            try
            {
                buff = _articlesDDL.SelectedValue;
                if (String.IsNullOrEmpty(buff))
                    return;

                if (!Int64.TryParse(buff, out articleId))
                    return;

                // if articleId == 0 then we want to select all
                if (articleId == 0)
                {
                    _commentsDS.SelectParameters.Clear();
                    _commentsDS.SelectCommand = _SELECT_ALL_COMMENTS;
                    _CommentsGV.EmptyDataText = Resources.Resources.NoComments;
                }
                else
                {
                    _commentsDS.SelectParameters.Clear();
                    _commentsDS.SelectCommand = _SELECT_COMMENTS_FOR_ARTICLE;
                    _commentsDS.SelectParameters.Add("@articleId", TypeCode.Int64, articleId.ToString());
                    _CommentsGV.EmptyDataText = Resources.Resources.NoComments + "&nbsp;(" + Resources.Resources.Article + ":&nbsp;" + Articles.GetArticleTitle(articleId.ToString()) + "&nbsp;)";
                }
            }
            catch (Exception)
            { 
            }
        }

        #endregion
    }
}
