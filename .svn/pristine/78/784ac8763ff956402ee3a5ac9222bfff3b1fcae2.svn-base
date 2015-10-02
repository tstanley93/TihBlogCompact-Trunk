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
    public class ConnectionStringsManager
    {
        public static string GetConnectionString()
        {
            string buff, result = "", connectionString, localPath;
            bool useLocal;

            try
            {
                buff = ConfigurationManager.AppSettings["useLocalConnString"];

                if (Boolean.TryParse(buff, out useLocal))
                {
                    // get connection string from web.config
                    connectionString = ConfigurationManager.ConnectionStrings["LocalAccessDatabase"].ConnectionString;
                    
                    // the mdb file is in local path ~/App_Data/
                    if (useLocal)
                    {
                        localPath = HostingEnvironment.ApplicationPhysicalPath;
                        result = connectionString.Replace("~", localPath);
                    }
                    else // the mdb file is hardcoded in the web.config file
                    {
                        result = connectionString;
                    }
                }
            }
            catch (Exception)
            { 
            }

            return result;
        }
    }
}
