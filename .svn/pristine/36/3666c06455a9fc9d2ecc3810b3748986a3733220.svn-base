using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace TihBlogCompact.Controls
{
    public class TBAccessDataSource : System.Web.UI.WebControls.AccessDataSource
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            DataFile = ConfigurationManager.AppSettings["dataFile"].ToString();
        }
    }
}
