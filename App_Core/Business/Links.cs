using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TihBlogCompact.Data.Tables;

namespace TihBlogCompact.Business
{
    public class Links
    {
        #region Public Methods

        public static void AddNew(string aURL, string aText)
        {
            int affectedRows;

            try
            {
                affectedRows = TableLinks.Insert(aURL, aText);

                if (affectedRows != 1)
                    throw new Exception("no affectedRows");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #endregion
    }
}
