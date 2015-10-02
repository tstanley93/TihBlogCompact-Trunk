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
using System.Xml;
using System.IO;
using System.Web.Configuration;
using TihBlogCompact.Business;

namespace TihBlogCompact
{
    public partial class adminSettings : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _updateButton.Text = Resources.Resources.Update;

                if (!IsPostBack)
                {
                    _pageTitleTagTB.Text = ConfigurationManager.AppSettings["titleTag"];
                    _blogTitleTB.Text = ConfigurationManager.AppSettings["blogTitle"];
                    _blogSubTitleTB.Text = ConfigurationManager.AppSettings["blogSubTitle"];
                    _cryptKeyTB.Text = ConfigurationManager.AppSettings["cryptKey"];
                    _commentsToShowTB.Text = ConfigurationManager.AppSettings["CommentsToShow"];
                    _articlesPerPageTB.Text = ConfigurationManager.AppSettings["ArticlesPerPage"];
                    _topArticlesCountTB.Text = ConfigurationManager.AppSettings["TopArticlesCount"];

                    _languagesDDL.SelectedValue = (WebConfigurationManager.GetSection("system.web/globalization") as GlobalizationSection).Culture;
                }
            }
            catch (Exception)
            { 
            }
        }

        protected void _updateButton_Click(object sender, EventArgs e)
        {
            Configuration config;
            bool bSave = false;
            PagesSection pagesSection;
            GlobalizationSection globalizationSection;
            string oldTitleTag = ConfigurationManager.AppSettings["titleTag"],
                   newTitleTag = _pageTitleTagTB.Text,
                   oldBlogTitle = ConfigurationManager.AppSettings["blogTitle"], 
                   newBlogTitle = _blogTitleTB.Text,
                   oldBlogSubTitle = ConfigurationManager.AppSettings["blogSubTitle"], 
                   newBlogSubTitle = _blogSubTitleTB.Text,
                   oldCryptKey = ConfigurationManager.AppSettings["cryptKey"],
                   newCryptKey = _cryptKeyTB.Text,
                   oldCommentsToShow = ConfigurationManager.AppSettings["CommentsToShow"], 
                   newCommentsToShow = _commentsToShowTB.Text,
                   oldArticlesPerPage = ConfigurationManager.AppSettings["ArticlesPerPage"],
                   newArticlesPerPage = _articlesPerPageTB.Text,
                   oldTopArticlesCount = ConfigurationManager.AppSettings["TopArticlesCount"],
                   newTopArticlesCount = _topArticlesCountTB.Text,
                   newTheme = _themesDDL.SelectedValue;

            try
            {
                config = WebConfigurationManager.OpenWebConfiguration("~");

                newTitleTag = _pageTitleTagTB.Text;

                if (!newTitleTag.Equals(oldTitleTag))
                {
                    config.AppSettings.Settings["titleTag"].Value = newTitleTag;
                    bSave = true;
                }

                if (!newBlogTitle.Equals(oldBlogTitle))
                {
                    config.AppSettings.Settings["blogTitle"].Value = newBlogTitle;
                    bSave = true;         
                }

                if (!newBlogSubTitle.Equals(oldBlogSubTitle))
                {
                    config.AppSettings.Settings["blogSubTitle"].Value = newBlogSubTitle;
                    bSave = true;           
                }

                if (!newCryptKey.Equals(oldCryptKey))
                {
                    config.AppSettings.Settings["cryptKey"].Value = newCryptKey;
                    bSave = true;                 
                }

                if (!newCommentsToShow.Equals(oldCommentsToShow))
                {
                    config.AppSettings.Settings["CommentsToShow"].Value = newCommentsToShow ;
                    bSave = true;       
                }

                if (!newArticlesPerPage.Equals(oldArticlesPerPage))
                {
                    config.AppSettings.Settings["ArticlesPerPage"].Value = newArticlesPerPage;
                    bSave = true;           
                }

                if (!newTopArticlesCount.Equals(oldTopArticlesCount))
                {
                    config.AppSettings.Settings["TopArticlesCount"].Value = newTopArticlesCount;
                    bSave = true;                  
                }

                pagesSection = config.GetSection("system.web/pages") as PagesSection;
                if (!pagesSection.Theme.Equals(newTheme))
                {
                    pagesSection.Theme = newTheme;
                    bSave = true;
                }

                globalizationSection = config.GetSection("system.web/globalization") as GlobalizationSection;
                if (!globalizationSection.Culture.Equals(_languagesDDL.SelectedValue))
                {
                    globalizationSection.Culture = _languagesDDL.SelectedValue;
                    bSave = true;
                }

                if (bSave)
                    config.Save();

                // if crypt key is changed we must update passwords in db
                if (!oldCryptKey.Equals(newCryptKey))
                {
                    Business.Authors.ChangeCryptKey(oldCryptKey, newCryptKey);
                }

                _resultLbl.Text = Resources.Resources.SettingsUpdated + "!";
            }
            catch (Exception)
            {
                _resultLbl.Text = Resources.Resources.UnknownError;
            }
        }

        protected void _themesDDL_Init(object sender, EventArgs e)
        {
            DropDownList themesDDL;
            DirectoryInfo di;

            try
            {
                themesDDL = sender as DropDownList;

                if (themesDDL != null)
                {
                    // if pictures has not Items, we load all picture files
                    if (themesDDL.Items.Count == 0)
                    {
                        di = new DirectoryInfo(Server.MapPath("~/App_Themes"));

                        themesDDL.DataSource = di.GetDirectories();

                        themesDDL.DataTextField = "Name";
                        themesDDL.DataValueField = "Name";

                        themesDDL.DataBind();

                        themesDDL.SelectedValue = Page.Theme;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
