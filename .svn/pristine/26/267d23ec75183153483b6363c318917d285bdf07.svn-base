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
using TihBlogCompact.Core;

namespace TihBlogCompact.Controls
{
    public partial class clientImagesControl : System.Web.UI.UserControl
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            string imagesPath, localPath, src;
            DirectoryInfo di;
            HtmlGenericControl br;
            

            try
            {
                if (!IsPostBack)
                {
                    imagesPath = ImagesPathsManager.GetClientImagesPhysicalPath();
                    localPath = ImagesPathsManager.GetClientImagesLocalPath();
                    di = new DirectoryInfo(imagesPath);
                    br = new HtmlGenericControl("br");
                    src = localPath.Replace('~', '.');
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        HyperLink link = new HyperLink();
                        link.Text = src + fi.Name;
                        link.NavigateUrl = localPath + fi.Name;
                        link.Attributes.Add("rel", "lightbox");
                        _imagesPH.Controls.Add(link);
                        _imagesPH.Controls.Add(br);
                        _imagesPH.Controls.Add(br);


                        /*t
                        label = new Label();
                        label.ID = "_clientLabel" + i;
                        label.Text = src + fi.Name;

                        _imagesPH.Controls.Add(label);

                        image = new Image();
                        image.ID = "_clientImage" + i;
                        image.ImageUrl = localPath + fi.Name;

                        _imagesPH.Controls.Add(image);

                        _imagesPH.Controls.Add(br);
                        _imagesPH.Controls.Add(br);

                        ++i;
                         */
                    }

                    
                    /*t
                    imagesPath = ImagesPathsManager.GetClientImagesPhysicalPath();
                    localPath = ImagesPathsManager.GetClientImagesLocalPath();
                    di = new DirectoryInfo(imagesPath);
                    br = new HtmlGenericControl("br");
                    src = localPath.Replace('~', '.');
                    i = 0;
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        label = new Label();
                        label.ID = "_clientLabel" + i;
                        label.Text = src + fi.Name;
                        
                        _imagesPH.Controls.Add(label);

                        image = new Image();
                        image.ID = "_clientImage" + i;
                        image.ImageUrl = localPath + fi.Name;

                        _imagesPH.Controls.Add(image);
                        
                        _imagesPH.Controls.Add(br);
                        _imagesPH.Controls.Add(br);
                        
                        ++i;
                    }
                    t*/
                }
            }
            catch (Exception)
            { 
            }
        }

        #endregion
    }
}