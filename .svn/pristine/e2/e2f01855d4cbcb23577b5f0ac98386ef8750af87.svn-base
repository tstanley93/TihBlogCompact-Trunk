using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Hosting;

namespace TihBlogCompact.Core
{
    public class ImagesPathsManager
    {
        public static string GetClientImagesPhysicalPath()
        {
            string buff, result = "", localPath;

            try
            {
                buff = ConfigurationManager.AppSettings["clientImagesPath"];

                // if the image directory is in local path  ~/images/client
                if (buff.Contains("~"))
                {
                    localPath = HostingEnvironment.ApplicationPhysicalPath;
                    result = buff.Replace("~", localPath);
                }
                else // the image directory is hardcoded in the web.config file
                {
                    result = buff;
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        public static string GetClientImagesLocalPath()
        {
            return ConfigurationManager.AppSettings["clientImagesPath"];
        }
    }
}
