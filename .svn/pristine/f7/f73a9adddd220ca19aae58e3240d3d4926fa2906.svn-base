using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace TihBlogCompact
{
    public class TBConvertor
    {
        public static string HTMLtoPlainText(string aHTML)
        {
            // Removes tags from passed HTML           
            System.Text.RegularExpressions.Regex objRegEx = new System.Text.RegularExpressions.Regex("<[^>]*>");

            return objRegEx.Replace(aHTML, "");
        }
    }
}
