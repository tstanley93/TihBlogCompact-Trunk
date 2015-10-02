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

using System.Globalization;
using System.Resources;

using TihBlogCompact.Business;
using TihBlogCompact.Core;

namespace TihBlogCompact
{
    public partial class main : System.Web.UI.MasterPage
    {
        #region Private Members

        private List<DateTime> _articlesDatesList;
        private DateTime _selectedDate;
        private const string _SELECT_TOP_ARTICLES = " [title], " +
                                                    "[ID], " +
                                                    "[rating] " +
                                                    "FROM [Articles] " +
                                                    "ORDER BY [rating] DESC, [published] DESC";      

        #endregion

        #region Constructor(s)

        public main()
        {
     
            _articlesDatesList = Articles.GetAllArticlesPublishedDates();
            _selectedDate = DateTime.MinValue;
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            _eventsCalendar.UseAccessibleHeader = false;

            int year, month, day;
            string buff;

            try
            {
                if (Int32.TryParse(Request.QueryString["year"], out year)
                    && Int32.TryParse(Request.QueryString["month"], out month)
                    && Int32.TryParse(Request.QueryString["day"], out day))
                {
                    _selectedDate = new DateTime(year, month, day);

                    // set selected 
                    _eventsCalendar.SelectedDate = _selectedDate.Date;
                    _eventsCalendar.VisibleDate = _selectedDate.Date;
                }

                buff = ConfigurationManager.AppSettings["TopArticlesCount"];
                if (buff != null)
                {
                    _topArticlesDS.SelectCommand = "SELECT TOP " + buff + _SELECT_TOP_ARTICLES;
                }

                if (IsPostBack)
                {
                    _rssHL.NavigateUrl = "~/rssArticles.ashx";
                }

                
            }
            catch (Exception)
            { 
            }
        }

        protected void _eventsCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            TbComparer tbComparer;
            int compare;
            HyperLink hyperLink;
            LiteralControl literalControl;

            try
            {
                if (_articlesDatesList == null)
                    throw new Exception("Cannot read articles dates");

                tbComparer = new TbComparer();
                compare = _articlesDatesList.BinarySearch(e.Day.Date, tbComparer);
                if (e.Cell.Controls.Count > 0)
                {
                    literalControl = e.Cell.Controls[0] as LiteralControl;
                    if (literalControl != null)
                    {
                        hyperLink = new HyperLink();
                        hyperLink.Text = literalControl.Text;
                        hyperLink.NavigateUrl = ResolveUrl("~/Default.aspx?year=" + e.Day.Date.Year + "&month=" + e.Day.Date.Month + "&day=" + e.Day.Date.Day);
                        hyperLink.CssClass = "TopArticlesLinks";
                        if (compare >= 0)
                        {
                            //We found that an Article was published on this exact day.
                            //  Grab the Article Date belonging to this exact day.
                            DateTime[] ThisArticleDate = new DateTime[_articlesDatesList.Count];
                            for (int i = 0; i < _articlesDatesList.Count; i++)
                            {
                                if (_articlesDatesList[i].Date == e.Day.Date.Date)
                                {
                                    ThisArticleDate[i] = _articlesDatesList[i];                                    
                                }
                            }

                            //Grab the Article Titles belonging to this exact day.  
                            string[] ArticleTitle = new string[ThisArticleDate.Length];
                            for (int i = 0; i < ThisArticleDate.Length; i++)
                            {
                                DateTime dt = new DateTime();
                                if (ThisArticleDate[i] == dt)
                                {
                                }
                                else
                                {
                                    ArticleTitle[i] = Articles.GetArticleTitleByDate(ThisArticleDate[i]);   
                                }
                            } 
                            
                            //Populate the ToolTip Div to show the user on mouseover the Article Title.                            
                            string ToolTipDiv = "";
                            for (int i = 0; i < ArticleTitle.Length; i++)
                            {
                                if (ArticleTitle[i] == null)
                                {
                                }
                                else
                                {
                                    ToolTipDiv += ArticleTitle[i] + "."; 
                                }
                            }                                                        
    
                            //Assign the Article Title to the Tool Tip for this Day.
                            hyperLink.Attributes["onmouseout"] = "PopulateDiv(event,'ToolTipDiv', '" + ToolTipDiv + "')";
                            hyperLink.Attributes["onmouseover"] = "PopulateDiv(event,'ToolTipDiv', '" + ToolTipDiv + "')";                            
                            hyperLink.Style.Add("color", System.Drawing.ColorTranslator.ToHtml(_eventsCalendar.SelectorStyle.ForeColor));
                            hyperLink.ToolTip = "";

                        }
                        else
                        {
                            hyperLink.Style.Add("color", System.Drawing.ColorTranslator.ToHtml(_eventsCalendar.ForeColor));
                            
                            //If there are no Aticles for this day, then...
                            hyperLink.ToolTip = "No Articles on this day.";
                        }
                        

                        e.Cell.Controls.Clear();
                        e.Cell.Controls.Add(hyperLink);
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
