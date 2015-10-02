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
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TihBlogCompact.Controls
{
    public partial class commentsControl : System.Web.UI.UserControl
    {
        #region Static Methods

        public static string ReplaceTag(string aText, string aTagName, string aReplaceWith)
        {
            string result;

            // checks for <dangerTag />
            string pattern = @"<.*?" + aTagName + @".*?/>";

            result = Regex.Replace(aText, pattern, aReplaceWith, RegexOptions.IgnoreCase);

            // checks for <dangerTag> ... </dangerTag>
            pattern = @"<.*?" + aTagName + @".*?>.*?</.*?" + aTagName + @".*?>";

            result = Regex.Replace(result, pattern, aReplaceWith, RegexOptions.IgnoreCase);
            
            return result;
        }

        #endregion

        #region Private Members

        private string _flagsPath;
        private string _jscriptFlagsPath;
        private string[] _dangerousTags = {"applet", 
                                           "body", 
                                           "embed",
                                           "iframe",
                                           "frame", 
                                           "script", 
                                           "frameset", 
                                           "html",
                                           "style", 
                                           "layer",
                                           "ilayer", 
                                           "meta",
                                           "object"}; 

        #endregion

        #region Constructor(s)

        public commentsControl()
        {
            _flagsPath = "";
            _jscriptFlagsPath = "";
        }

        #endregion

        #region Public Properties

        public string FlagsPath
        {
            get
            {
                return _flagsPath;
            }
            set
            {
                _flagsPath = value;
            }
        }

        public string JScriptFlagsPath
        {
            get
            {
                return _jscriptFlagsPath;
            }
            set
            {
                _jscriptFlagsPath = value;
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _countriesDdl.Attributes.Add("onchange", "SetFlag(" + _imgFlag.ClientID + ", this.value)");
                BindCountries();
            }
            SetFlagImageUrl();
        }

        #endregion

        #region Public Methods

        public string GetName()
        {
            return _nameTB.Text;
        }

        public string GetEmail()
        {
            return _emailTB.Text;
        }

        public string GetWebSite()
        {
            return _websiteTB.Text;
        }

        public string GetCountry()
        {
            return _countriesDdl.SelectedValue;
        }

        public string GetComment()
        {
            string result = _fckEditor.Value;

            for (int i = 0; i < _dangerousTags.Length; ++i)
            {
                result = ReplaceTag(result, _dangerousTags[i], "");
            }
            
            return result;
        }

        public int GetRating()
        {
            int result = 0;
            Int32.TryParse(_ratingDDL.SelectedValue, out result);
            
            return result;
        }

        #endregion

        #region Private Methods

        public void BindCountries()
        {
            StringDictionary dic = new StringDictionary();
            List<string> col = new List<string>();

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo ri = new RegionInfo(ci.Name);
                if (!dic.ContainsKey(ri.EnglishName))
                    dic.Add(ri.EnglishName, ri.TwoLetterISORegionName.ToLowerInvariant());

                if (!col.Contains(ri.EnglishName))
                    col.Add(ri.EnglishName);
            }

            col.Sort();

            _countriesDdl.Items.Add(new ListItem("[Not specified]", ""));
            foreach (string key in col)
            {
                _countriesDdl.Items.Add(new ListItem(key, dic[key]));
            }

            if (_countriesDdl.SelectedIndex == 0 && Request.UserLanguages != null && Request.UserLanguages[0].Length == 5)
            {
                _countriesDdl.SelectedValue = Request.UserLanguages[0].Substring(3);
            }
        }

        private void SetFlagImageUrl()
        {
            if (!string.IsNullOrEmpty(_countriesDdl.SelectedValue))
            {
                _imgFlag.ImageUrl = _flagsPath + _countriesDdl.SelectedValue + ".png";
            }
            else
            {
                _imgFlag.ImageUrl = _flagsPath + "pixel.png";
            }
        }

        #endregion
    }
}