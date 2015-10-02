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
    /// <summary>
    /// Control for checkbox, which values are strings
    /// "1" is true, everything else - false
    /// </summary>
    public class TBCheckBox : System.Web.UI.WebControls.CheckBox
    {
        #region Public Properties

        public string TBChecked
        {
            get
            {
                if (Checked)
                    return "1";
                return "0";
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (value.Equals("1"))
                        Checked = true;
                    else
                        Checked = false;
                }
                else
                    Checked = false;
            }
        }

        #endregion
    }
}
