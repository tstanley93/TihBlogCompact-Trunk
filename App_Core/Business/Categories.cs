using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TihBlogCompact.Business;

namespace TihBlogCompact.Business
{
    public class Categories
    {
        public static bool TryParse(string aCategoryId, out string aCategoryName)
        {
            bool result = false;
            Int64 categoryId;
            aCategoryName = null;
            
            try
            {
                if (Int64.TryParse(aCategoryId, out categoryId))
                {
                    result = TableCategory.ReadCategory(categoryId, out aCategoryName);
                }
            }
            catch (Exception)
            { 
            }

            return result;
        }
    }
}
