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
using RssToolkit;

namespace TihBlogCompact
{
    public partial class Article : BasePage
    {
        #region Private Members

        private const string _SELECT_COMMENTS = " [ID], [articleId], [names], [email], [website], [comment], [published], [country], [rating] " +
                                                "FROM [Comments] " +
                                                "WHERE [articleId]=@articleId " +
                                                "ORDER BY [published] DESC ";

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            string buff;
            bool validArticleId = false;

            try
            {
                _addButton.Text = Resources.Resources.Add;

                buff = Request.QueryString["articleId"];
                if (String.IsNullOrEmpty(buff))
                    validArticleId = false;
                else if (Articles.ArticleExist(buff))
                    validArticleId = true;

                if (validArticleId)
                {
                    _noarticlePanel.Visible = false;
                    _articlePanel.Visible = true;
                }
                else
                {
                    _noarticlePanel.Visible = true;
                    _errorArticleIdLbl.Text = Resources.Resources.NoArticleSelected + "!";
                    _articlePanel.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void _articleRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            DataRowView item;
            object obj;
            int allowComments, count;
            Label label;
            bool showComments;

            try
            {
                item = e.Item.DataItem as DataRowView;

                if (item != null)
                {
                    obj = item.Row["allowComments"];
                    if (obj != null)
                    {
                        allowComments = Int32.Parse(obj.ToString());

                        // if comments are allowed
                        if (allowComments == 1)
                        {
                            // get article's ID
                            obj = item.Row["articleID"];

                            // get comments count
                            if (obj != null)
                                count = Articles.GetCommentsCountForArticle(obj.ToString());
                            else
                                count = 0;

                            showComments = IsShowCommentsParamSet();
                            _showCommentsLnkBtn.Text = Resources.Resources.ShowComments + "&nbsp;(" + count.ToString() + ")";
                            _showCommentsLnkBtn.Visible = !showComments;
                            _hideCommentsLnkBtn.Text = Resources.Resources.HideComments + "&nbsp;(" + count.ToString() + ")";
                            _hideCommentsLnkBtn.Visible = showComments;
                            // show add new comments
                            _addCommentPanel.Visible = true;
                        }
                        else // comments are not allowed
                        {
                            label = new Label();
                            label.Text = Resources.Resources.CommentsAreOff;
                            _articleFooterPanel.Controls.Add(label);
                            // hide add new comments
                            _addCommentPanel.Visible = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void _articleDS_Init(object sender, EventArgs e)
        {
            string buff;
            Int64 articleId;
            bool bContinue;

            try
            {
                _articleDS.SelectParameters.Clear();

                buff = Request.QueryString["articleId"];
                bContinue = !String.IsNullOrEmpty(buff);
                if (bContinue)
                {
                    bContinue = Int64.TryParse(buff, out articleId);    
                }

                if (bContinue)
                    _articleDS.SelectParameters.Add("articleID", TypeCode.Int64, buff);
                else
                    _articleDS.SelectParameters.Add("articleID", TypeCode.Int64, "-1");
            }
            catch (Exception)
            {
            }
        }

        protected void _commentsDS_Init(object sender, EventArgs e)
        {
            string buff;
            Int64 articleId;
            bool bContinue;
            bool showAllComments;

            try
            {
                showAllComments = IsShowCommentsParamSet();
                _commentsDS.SelectCommand = GetSelectCommand(showAllComments);

                _commentsDS.SelectParameters.Clear();

                buff = Request.QueryString["articleId"];
                bContinue = !String.IsNullOrEmpty(buff);
                if (bContinue)
                {
                    bContinue = Int64.TryParse(buff, out articleId);
                }

                if (bContinue)
                    _commentsDS.SelectParameters.Add("articleID", TypeCode.Int64, buff);
                else
                    _commentsDS.SelectParameters.Add("articleID", TypeCode.Int64, "-1");
            }
            catch (Exception)
            {
            }
        }

        protected void _addButton_Click(object sender, EventArgs e)
        {
            string articleId, names, email, webSite, comment, country;
            int rating;
            HtmlInputHidden myhidcontrol = this.FindControl("ctl00$_mainContentPlaceHolder$txtHidData") as HtmlInputHidden;

            if (myhidcontrol.Value == "true")
            {
                try
                {
                    articleId = Request.QueryString["articleId"];

                    if (String.IsNullOrEmpty(articleId))
                        throw new Exception("No article's ident specified!");

                    names = _commentsControl.GetName();
                    email = _commentsControl.GetEmail();
                    webSite = _commentsControl.GetWebSite();
                    comment = _commentsControl.GetComment();
                    country = _commentsControl.GetCountry();
                    rating = _commentsControl.GetRating();

                    if (comment.Length == 0)
                    {
                        _resultLbl.Text = Resources.Resources.EnterComment + "!";
                        return;
                    }

                    Articles.AddNewComment(articleId, names, email, webSite, comment, country, rating);

                    _commentsDS.DataBind();
                    _commentsRepeater.DataBind();

                    _articleDS.DataBind();
                    _articleRepeater.DataBind();

                    _resultLbl.Text = Resources.Resources.CommentAdded;
                }
                catch (Exception)
                {
                    _resultLbl.Text = Resources.Resources.UnknownError;
                } 
            }
        }

        protected void _commentsRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            Image flagImage;
            DataRowView item;
            object obj;
            string country = "";
            bool bSucceeded = false;

            flagImage = e.Item.FindControl("_flagImage") as Image;

            if (flagImage != null)
            {
                item = e.Item.DataItem as DataRowView;
                if (item != null)
                {
                    obj = item.Row["country"];
                    if (obj != null)
                        country = obj.ToString();

                    if (!String.IsNullOrEmpty(country))
                    {
                        flagImage.ImageUrl = "~/images/flags/" + country + ".png";
                        flagImage.AlternateText = country;
                        bSucceeded = true;
                    }
                }

                if (!bSucceeded)
                {
                    flagImage.ImageUrl = "~/images/flags/pixel.png";
                    flagImage.AlternateText = "";
                }
            }
        }

        protected void _showCommentsLnkBtn_Click(object sender, EventArgs e)
        {
            _commentsDS.SelectCommand = GetSelectCommand(true);
            _commentsDS.DataBind();
            _commentsRepeater.DataBind();

            _showCommentsLnkBtn.Visible = false;
            _hideCommentsLnkBtn.Visible = true;
        }

        protected void _hideCommentsLnkBtn_Click(object sender, EventArgs e)
        {
            _commentsDS.SelectCommand = GetSelectCommand(false);
            _commentsDS.DataBind();
            _commentsRepeater.DataBind();

            _showCommentsLnkBtn.Visible = true;
            _hideCommentsLnkBtn.Visible = false;
        }

        protected void _commentsRepeater_PreRender(object sender, EventArgs e)
        {
            bool anyCommentPosted, commentsAreOn, showCommentsTitle;
            Literal literal;

            try
            {
                anyCommentPosted = (_commentsRepeater.Items.Count > 0);
                commentsAreOn = _addCommentPanel.Visible;
                
                // if there no comments and article not allow comments, we hide comments title
                showCommentsTitle = anyCommentPosted || commentsAreOn;

                _commentsTitlePanel.Visible = showCommentsTitle;

                // comments are allowed and there no comments we add text 'No Comments Yet'
                if (showCommentsTitle && !anyCommentPosted)
                {
                    literal = new Literal();
                    literal.Text = Resources.Resources.NoCommentsYet + ".";
                    _commentsAdditionalInfoPH.Controls.Add(literal);
                }
                else
                {
                    _commentsAdditionalInfoPH.Controls.Clear();
                }

                _rssHL.Visible = commentsAreOn;
            }
            catch (Exception)
            { 
            }
        }

        protected void _rssHL_Load(object sender, EventArgs e)
        {
            RssHyperLink hyperLink;
            Label label;
            Image image;

            try
            {
                hyperLink = sender as RssHyperLink;
                if (hyperLink != null)
                {
                    hyperLink.Controls.Clear();

                    // rss text
                    label = new Label();
                    label.Text = "Post RSS";
                    hyperLink.Controls.Add(label);

                    // rss image
                    image = new Image();
                    image.ImageUrl = "~/images/rssBtn.gif";
                    image.AlternateText = "Subscribe to RSS Feed";
                    hyperLink.Controls.Add(image);

                    hyperLink.ChannelName = GetRssCommentsChannelName(Request.QueryString["articleId"]);
                    hyperLink.NavigateUrl = "~/rssComments.ashx";
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Public Methods

        public string GetRating(object obj)
        {
            string result = "-";

            if (obj != null && !obj.ToString().Equals("-1"))
                result = obj.ToString();

            return result;
        }

        public string GetRssCommentsChannelName(object articleId)
        {
            if (articleId == null)
                return "comments for article #";

            return "comments for article #" + articleId.ToString();
        }

        #endregion

        #region Private Methods

        private string GetSelectCommand(bool bSelectAll)
        {
            string result = "";
            string buff;
            int tmp;

            if (bSelectAll)
            {
                result = "SELECT " + _SELECT_COMMENTS;
            }
            else
            {
                buff = ConfigurationManager.AppSettings["CommentsToShow"];
                if (String.IsNullOrEmpty(buff))
                    result = "SELECT " + _SELECT_COMMENTS;
                else if (buff.ToLower().Equals("all"))
                    result = "SELECT " + _SELECT_COMMENTS;
                else if (Int32.TryParse(buff, out tmp))
                    result = "SELECT TOP " + buff + " " + _SELECT_COMMENTS;
                else
                    result = "SELECT " + _SELECT_COMMENTS;
            }

            return result;
        }

        private bool IsShowCommentsParamSet()
        {
            string buff;
            bool result = false;

            try
            {
                buff = Request.Params["comments"];

                if (!String.IsNullOrEmpty(buff))
                    Boolean.TryParse(buff, out result);
            }
            catch (Exception)
            { 
            }

            return result;
        }

        #endregion
    }
}
