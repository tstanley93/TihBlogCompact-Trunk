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
using TihBlogCompact.Business;
using RssToolkit;

namespace TihBlogCompact
{
    public partial class _Default : BasePage
    {
        #region Private Members

        private const string _SELECT_ARTICLES_BY_DATE = "SELECT A.[ID] as ID, " +
                                                               "A.[authorId] as authorId, " +
                                                               "A.[published] as published, " +
                                                               "A.[allowComments] as allowComments, " +
                                                               "A.[title] as title, " +
                                                               "A.[content] as content, " +
                                                               "P.[names] as publisher " +
                                                        "FROM [Articles] A, [Authors] P " +
                                                        "WHERE A.[authorId] = P.[ID] AND (A.[published] BETWEEN @begPublished AND @endPublished) " +
                                                        "ORDER BY [published] DESC";
        private const string _SELECT_ARTICLES_BY_CATEGORY = "SELECT A.[ID] as ID, " +
                                                                   "A.[authorId] as authorId, " +
                                                                   "A.[published] as published, " +
                                                                   "A.[allowComments] as allowComments, " +
                                                                   "A.[title] as title, " +
                                                                   "A.[content] as content, " +
                                                                   "P.[names] as publisher " +
                                                            "FROM [Articles] A, [Authors] P " +
                                                            "WHERE A.[authorId] = P.[ID] AND ( " +
                                                            "(A.[ID] IN (SELECT [articleId] FROM [ArticleCategories] WHERE [categoryId] = 1) ) " +
                                                            "          OR " +
                                                            " (A.[ID] IN (SELECT [articleId] FROM [ArticleCategories] WHERE [categoryId] = @categoryId) ) " +
                                                            " ) " +
                                                            " ORDER BY [published] DESC ";
        private const string _SELECT_ARTICLES = "SELECT A.[ID] as ID, " +
                                                       "A.[authorId] as authorId, " + 
                                                       "A.[published] as published, " +
                                                       "A.[allowComments] as allowComments, " + 
                                                       "A.[title] as title, " +
                                                       "A.[content] as content, " +
                                                       "P.[names] as publisher " +
                                                "FROM [Articles] A, [Authors] P " +
                                                "WHERE A.[authorId] = P.[ID] " +
                                                "ORDER BY [published] DESC";

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            int year, month, day;
            Panel panel;
            LiteralControl literalControl;
            string categoryName;
            Int64 categoryId;

            try
            {
                // if date is selected by calendar
                if (Int32.TryParse(Request.QueryString["year"], out year) 
                    && Int32.TryParse(Request.QueryString["month"], out month)
                    && Int32.TryParse(Request.QueryString["day"], out day))
                {
                    DateTime beginDate = new DateTime(year, month, day, 0, 0, 0, 0);
                    DateTime endDate = new DateTime(year, month, day, 23, 59, 59, 999);
                    
                    _topArticlesDS.SelectCommand = _SELECT_ARTICLES_BY_DATE;

                    _topArticlesDS.SelectParameters.Clear();
                    _topArticlesDS.SelectParameters.Add("begPublished", TypeCode.DateTime, beginDate.ToString());
                    _topArticlesDS.SelectParameters.Add("endPublished", TypeCode.DateTime, endDate.ToString());

                    panel = new Panel();
                    panel.CssClass = "blogSubTitle";
                    literalControl = new LiteralControl();
                    literalControl.Text = Resources.Resources.Date + ":&nbsp;" + beginDate.ToString("dd MMMM yyyy");
                    panel.Controls.Add(literalControl);

                    _selectedFilterPH.Controls.Add(panel);
                } 
                // all categories is seleted
                else if (Int64.TryParse(Request.QueryString["categoryId"], out categoryId) && categoryId == 1)
                {
                    _topArticlesDS.SelectCommand = _SELECT_ARTICLES;
                    _topArticlesDS.SelectParameters.Clear();

                    panel = new Panel();
                    panel.CssClass = "blogSubTitle";
                    literalControl = new LiteralControl();
                    literalControl.Text = Resources.Resources.AllCategories;
                    panel.Controls.Add(literalControl);

                    _selectedFilterPH.Controls.Add(panel);
                }
                // custom category i selected
                else if (Categories.TryParse(Request.QueryString["categoryId"], out categoryName))
                {
                    _topArticlesDS.SelectCommand = _SELECT_ARTICLES_BY_CATEGORY;
                    _topArticlesDS.SelectParameters.Clear();
                    _topArticlesDS.SelectParameters.Add("categoryId", TypeCode.Int64, Request.QueryString["categoryId"]);

                    panel = new Panel();
                    panel.CssClass = "blogSubTitle";
                    literalControl = new LiteralControl();
                    literalControl.Text = Resources.Resources.CategoryName + ":&nbsp;" + categoryName;
                    panel.Controls.Add(literalControl);

                    _selectedFilterPH.Controls.Add(panel);
                }

                // set empty data text to Articles GridView
                _ArticlesGV.EmptyDataText = Resources.Resources.NoArticles + "!";
            }
            catch (Exception)
            { 
            }
        }

        protected void _ArticlesGV_Init(object sender, EventArgs e)
        {
            object obj;
            int pageSize;

            try
            {
                obj = ConfigurationManager.AppSettings["ArticlesPerPage"];
                if (obj != null && int.TryParse(obj.ToString(), out pageSize))
                { 
                    // set page size for articles
                    _ArticlesGV.PageSize = pageSize;
                }
                
            }
            catch (Exception)
            { 
            }
        }

        protected void _rssHL_Load(object sender, EventArgs e)
        {
            RssHyperLink hyperLink;
            Label label, txtLabel;
            Image image;

            try
            {
                // it's bug: on async postback, navigateurl loses ~ of the virtual path
                // "~/rssArticles.ashx" becomes "/rssArticles.ashx"
                if (IsPostBack)
                {
                    hyperLink = sender as RssHyperLink;
                    if (hyperLink != null)
                    {
                        // label.Text contains ID of the article, somehow the rss hyperLink loses all: text, channelName, etc.
                        label = hyperLink.Parent.FindControl("_hiddenArticleId") as Label;
                        if (label != null && !string.IsNullOrEmpty(label.Text))
                        {
                            // rss text
                            txtLabel = new Label();
                            txtLabel.Text = "Post RSS";
                            hyperLink.Controls.Add(txtLabel);

                            // rss image
                            image = new Image();
                            image.ImageUrl = "~/images/rssBtn.gif";
                            image.AlternateText = "Subscribe to RSS Feed";
                            hyperLink.Controls.Add(image);

                            hyperLink.ChannelName = GetRssCommentsChannelName(label.Text);
                            hyperLink.NavigateUrl = "~/rssComments.ashx";
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Public Methods

        public bool AllowComments(object obj)
        {
            int i;

            if (obj != null & Int32.TryParse(obj.ToString(), out i))
                return i == 1;

            return true;
        }

        public string GetCommentsCount(object articleId)
        {
            if (articleId != null)
                return Articles.GetCommentsCountForArticle(articleId.ToString()).ToString();

            return "";
        }

        public string GetRssCommentsChannelName(object articleId)
        {
            if (articleId == null)
                return "";

            return "comments for article #" + articleId.ToString();
        }

        public string PostedIn(object articleId)
        { 
            List<Dictionary<string, string>> articleCategories;
            Dictionary<string, string> category;
            StringBuilder sb = new StringBuilder(250);

            if (articleId != null)
            {
                articleCategories = Articles.GetArticlesCategories(articleId.ToString());
                if (articleCategories != null)
                {
                    sb.Append("<b>" + Resources.Resources.PostedIn + ":</b>&nbsp;");

                    for (int i = 0; i < articleCategories.Count; ++i)
                    {
                        category = articleCategories[i];

                        sb.Append("<a class='simple_link area_link postedIn' href='Default.aspx?categoryId=" + category["id"] + "'>" + category["name"] + "</a>&nbsp;");
                    }
                }
            }

            return sb.ToString();
        }

        #endregion
    }
}
