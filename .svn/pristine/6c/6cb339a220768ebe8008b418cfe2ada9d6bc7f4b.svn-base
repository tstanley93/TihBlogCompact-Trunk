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
using System.Web.Hosting;
using System.IO;

namespace TihBlogCompact.Admin
{
    public partial class adminImagesManager : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _uploadImageBtn.Text = Resources.Resources.UploadImage;

                if (!Page.IsPostBack)
                {
                    // load files to be dispalyed
                    LoadFilesDataSource();
                }
            }
            catch (Exception)
            { 
            }
        }

        protected void _uploadImageBtn_Click(object sender, EventArgs e)
        {
            string imagesFolder;
            string absolutePath;

            try
            {
                if (String.IsNullOrEmpty(_imageFU.FileName))
                    throw new Exception("file not selected");

                // get images folder
                imagesFolder = ConfigurationManager.AppSettings["imagesPath"];

                if (String.IsNullOrEmpty(imagesFolder))
                    throw new Exception("empty image path");

                absolutePath = HostingEnvironment.MapPath(imagesFolder);

                _imageFU.SaveAs(absolutePath + _imageFU.FileName);

                _uploadResultLbl.Text = Resources.Resources.FileSuccessfullyUploaded;

                // refresh data source
                LoadFilesDataSource();
            }
            catch (Exception)
            {
                _uploadResultLbl.Text = Resources.Resources.UnknownError;
            }
        }

        protected void _imagesGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LinkButton deleteLnkBtn;
            string fileName;

            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    deleteLnkBtn = e.CommandSource as LinkButton;
                    if (deleteLnkBtn != null)
                    {
                        fileName = deleteLnkBtn.CommandArgument;

                        if (!String.IsNullOrEmpty(fileName))
                        {
                            File.Delete(fileName);
                            LoadFilesDataSource();
                        }
                    }
                }
            }
            catch (Exception)
            { 
            }
        }

        protected void _imagesGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion

        #region Public Methods

        public string GetImageURL(object aFileName)
        {
            return ResolveUrl(ConfigurationManager.AppSettings["imagesPath"] + aFileName.ToString());
        }

        #endregion

        #region Private Methods

        private void LoadFilesDataSource()
        {
            string imagesPath;
            DirectoryInfo di;

            try
            {
                imagesPath = ConfigurationManager.AppSettings["imagesPath"];
                if (String.IsNullOrEmpty(imagesPath))
                    throw new Exception("empty image path");

                di = new DirectoryInfo(Server.MapPath(imagesPath));

                _imagesGV.DataSource = di.GetFiles();
                _imagesGV.DataBind();
            }
            catch (Exception)
            { 
            }
        }

        #endregion
    }
}
