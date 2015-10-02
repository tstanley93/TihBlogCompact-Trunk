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
using System.IO;

namespace TihBlogCompact.Admin
{
    public partial class adminAuthor : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

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
/*
                        previewAuthorImage = picturesDDL.Parent.FindControl("_previewAuthorImage") as Image;

                        if (previewAuthorImage != null)
                        {
                            previewAuthorImage.ImageUrl = imagesPath + picturesDDL.SelectedValue;
                        }
 */
                    }
                    else
                    { 
                    
                    }
                }
            }
            catch (Exception)
            { 
            }
        }

        protected void _picturesDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList picturesDDL;
            string imagesPath;
            Image previewAuthorImage;

            try
            {
                picturesDDL = sender as DropDownList;

                if (picturesDDL != null)
                {
                    imagesPath = ConfigurationManager.AppSettings["imagesPath"];

                    previewAuthorImage = picturesDDL.Parent.FindControl("_previewAuthorImage") as Image;
                    if (previewAuthorImage != null)
                    {
                        previewAuthorImage.ImageUrl = imagesPath + picturesDDL.SelectedValue;
                    }
                }
            }
            catch (Exception)
            { 
            }
        }
    }
}
