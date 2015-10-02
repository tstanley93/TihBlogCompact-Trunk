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
using System.IO;
using System.Web.Hosting;
using TihBlogCompact.Core;
using TihBlogCompact.Business;

namespace TihBlogCompact.Admin
{
    public partial class adminAddArticle : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            string allCategoriesId, categoriesDivId, imagesPath, filesPath;

            try
            {
                _addButton.Text = Resources.Resources.Add;
                _commentsAreOffChB.Text = Resources.Resources.CommentsAreOff;

                allCategoriesId = _categoriesControl.GetAllCategoriesClientID();
                categoriesDivId = _categoriesControl.GetCustomCategoriesDivClientID();

                _addButton.Attributes.Add("onclick", "return CheckArticleTitle('" + _titleTB.ClientID + "') && CheckCustomCategories('" + allCategoriesId + "', '" + categoriesDivId + "')");
                
                _insertImageBtn.Text = Resources.Resources.InsertSelectedImage;
                _insertFileBtn.Text = Resources.Resources.InsertSelectedFile;
                _viewImageHL.Text = Resources.Resources.View;

                imagesPath = ConfigurationManager.AppSettings["imagesPath"].Replace("~", "");
                
                _insertImageBtn.Attributes.Add("onclick", "return InsertImageToEditor('" + imagesPath + "', '" + _picturesDDL.ClientID + "', '" + _fckEditor.ClientID + "')");
                _picturesDDL.Attributes.Add("onchange", "OnChangeSelectedPicture('" + _picturesDDL.ClientID + "', '" + _viewImageHL.ClientID + "', '" + imagesPath + "')");

                filesPath = ConfigurationManager.AppSettings["filesPath"].Replace("~", "");

                _insertFileBtn.Attributes.Add("onclick", "return InsertFileToEditor('" + filesPath + "', '" + _filesDDL.ClientID + "', '" + _fckEditor.ClientID + "')");
            }
            catch (Exception)
            { 
            }
        }

        protected void _addButton_Click(object sender, EventArgs e)
        {
            string title, content, username;
            bool allowComments, toAllCategories;
            List<string> selectedCategories = null;

            try
            {
                title = _titleTB.Text;
                content = _fckEditor.Value;
                allowComments = !_commentsAreOffChB.Checked;

                username = Session[Constants.Session.USERNAME] as string;

                toAllCategories = _categoriesControl.AllCategoriesAreSelected();
                if (!toAllCategories)
                    selectedCategories = _categoriesControl.GetSelectedCategories();

                Articles.AddNewArticle(title, content, username, allowComments, toAllCategories, selectedCategories);

                _resultLbl.Text = Resources.Resources.ArticleAdded;
            }
            catch (Exception)
            {
                _resultLbl.Text = Resources.Resources.UnknownError;
            }
        }

        protected void _picturesDDL_Init(object sender, EventArgs e)
        {
            DropDownList picturesDDL;
            string imagesPath;
            DirectoryInfo di;

            try
            {
                picturesDDL = sender as DropDownList;

                if (picturesDDL != null)
                {
                    // if pictures has not Items, we load all picture files
                    if (picturesDDL.Items.Count == 0)
                    {
                        imagesPath = ConfigurationManager.AppSettings["imagesPath"];
                        if (String.IsNullOrEmpty(imagesPath))
                            throw new Exception("empty image path");

                        di = new DirectoryInfo(Server.MapPath(imagesPath));
                        picturesDDL.DataSource = di.GetFiles();

                        picturesDDL.DataTextField = "Name";
                        picturesDDL.DataValueField = "Name";

                        picturesDDL.DataBind();

                        _viewImageHL.NavigateUrl = imagesPath + picturesDDL.SelectedValue;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void _filesDDL_Init(object sender, EventArgs e)
        {
            DropDownList filesDDL;
            string filesPath;
            DirectoryInfo di;

            try
            {
                filesDDL = sender as DropDownList;

                if (filesDDL != null)
                {
                    // if files has not Items, we load all files
                    if (filesDDL.Items.Count == 0)
                    {
                        filesPath = ConfigurationManager.AppSettings["filesPath"];
                        if (String.IsNullOrEmpty(filesPath))
                            throw new Exception("empty files path");

                        di = new DirectoryInfo(Server.MapPath(filesPath));
                        filesDDL.DataSource = di.GetFiles();

                        filesDDL.DataTextField = "Name";
                        filesDDL.DataValueField = "Name";

                        filesDDL.DataBind();
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
