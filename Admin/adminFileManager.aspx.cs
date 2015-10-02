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
    public partial class adminFileManager : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _uploadFileBtn.Text = Resources.Resources.UploadFile;

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

        protected void _uploadFileBtn_Click(object sender, EventArgs e)
        {
            string filesFolder;
            string absolutePath;

            try
            {
                if (String.IsNullOrEmpty(_fileFU.FileName))
                    throw new Exception("file not selected");

                // get images folder
                filesFolder = ConfigurationManager.AppSettings["filesPath"];

                if (String.IsNullOrEmpty(filesFolder))
                    throw new Exception("empty file path");

                absolutePath = HostingEnvironment.MapPath(filesFolder);

                _fileFU.SaveAs(absolutePath + _fileFU.FileName);

                _uploadResultLbl.Text = Resources.Resources.FileSuccessfullyUploaded;

                // refresh data source
                LoadFilesDataSource();
            }
            catch (Exception)
            {
                _uploadResultLbl.Text = Resources.Resources.UnknownError;
            }
        }

        protected void _filesGV_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void _filesGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion

        #region Public Methods

        public string GetFileURL(object aFileName)
        {
            return ResolveUrl(ConfigurationManager.AppSettings["filesPath"] + aFileName.ToString());
        }

        #endregion

        #region Private Methods

        private void LoadFilesDataSource()
        {
            string filePath;
            DirectoryInfo di;

            try
            {
                filePath = ConfigurationManager.AppSettings["filesPath"];
                if (String.IsNullOrEmpty(filePath))
                    throw new Exception("empty file path");

                di = new DirectoryInfo(Server.MapPath(filePath));

                _filesGV.DataSource = di.GetFiles();
                _filesGV.DataBind();
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
