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
using System.Collections.Generic;
using System.Text;
using TihBlogCompact.Core;
using TihBlogCompact.Business;

namespace TihBlogCompact.Controls
{
    public partial class categoriesControl : System.Web.UI.UserControl
    {
        #region Private Members

        private bool _selectAll;
        private List<string> _selectedIds;
        private bool _automaticInitForArticle;

        #endregion

        #region Constructor(s)

        public categoriesControl()
        {
            _selectAll = true;
            _selectedIds = null;
            _automaticInitForArticle = false;
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _allRdoBtn.Text = Resources.Resources.AllCategories;
                _selectRdoBtn.Text = Resources.Resources.Select + "...";
            }
            catch (Exception)
            { 
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            string val;
            TbComparer tbComparer;
            int compare;

            try
            {
                base.OnPreRender(e);

                if (!IsPostBack || _automaticInitForArticle)
                {
                    _allRdoBtn.Checked = _selectAll;
                    _selectRdoBtn.Checked = !_selectAll;
                    // _customCategoriesPanel.Enabled = !_selectAll;

                    if (_selectedIds != null)
                    {
                        tbComparer = new TbComparer();

                        for (int i = 0; i < _categoriesChBList.Items.Count; ++i)
                        {
                            val = _categoriesChBList.Items[i].Value;
                            compare = _selectedIds.BinarySearch(val, tbComparer);

                            // if current item is in _selectedId
                            if (compare >= 0)
                                _categoriesChBList.Items[i].Selected = true;
                        }
                    }
                }

                _allRdoBtn.Attributes.Add("OnClick", "SetControlEnable('" + _customCategoriesPanel.ClientID + "', true)");
                _selectRdoBtn.Attributes.Add("OnClick", "SetControlEnable('" + _customCategoriesPanel.ClientID + "', false)");

            }
            catch (Exception)
            { 
            }
        }

        #endregion

        #region Public Properties

        public bool SelectAll
        {
            get
            {
                return _selectAll;
            }
            set
            {
                _selectAll = value;
            }
        }

        public List<string> SelectedIds
        {
            get
            {
                return _selectedIds;
            }
            set
            {
                _selectedIds = value;
            }
        }

        public object AutomaticInitForArticleId
        {
            set
            {
                if (value != null)
                {
                    InitCategoriesForArticle(value.ToString());
                    _automaticInitForArticle = true;
                }
            }
        }

        #endregion

        #region Public Method

        public void InitGroups(bool aSelectAll, List<string> aSelected)
        {
            try
            {
                if (aSelectAll)
                {
                    _allRdoBtn.Checked = true;
                    _selectRdoBtn.Checked = false;
                }
            }
            catch (Exception)
            { 
            }
        }

        public bool AllCategoriesAreSelected()
        {
            return _allRdoBtn.Checked;
        }

        public List<string> GetSelectedCategories()
        {
            ListItem listItem;
            List<string> result = new List<string>(_categoriesChBList.Items.Count);
            TbComparer tbComparer = new TbComparer();

            try
            {
                for (int i = 0; i < _categoriesChBList.Items.Count; ++i)
                {
                    listItem = _categoriesChBList.Items[i];
                    if (listItem.Selected)
                        result.Add(listItem.Value);
                }

                result.Sort(tbComparer);
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public string GetAllCategoriesClientID()
        {
            return _allRdoBtn.ClientID;
        }

        public string GetCustomCategoriesDivClientID()
        {
            return _customCategoriesPanel.ClientID;
        }

        #endregion

        #region Private Methods

        private void InitCategoriesForArticle(string aArticleId)
        {
            List<Dictionary<string, string>> categories;

            try
            {
                categories = Articles.GetArticlesCategories(aArticleId);

                if (categories != null)
                { 
                    // if article's in all categories
                    if (categories.Count == 1 && categories[0]["id"].Equals("1"))
                    {
                        _selectAll = true; 
                    }
                    else
                    {
                        _selectAll = false;

                        _selectedIds = new List<string>(categories.Count);
                        
                        for (int i = 0; i < categories.Count; ++i)
                        {
                            _selectedIds.Add(categories[i]["id"]);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}