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

namespace TihBlogCompact
{
    public partial class Authors : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            string buff;
            bool validAuthorId = true;

            try
            {
                buff = Request.QueryString["authorId"];
                if (String.IsNullOrEmpty(buff))
                    validAuthorId = false;
                else if (TihBlogCompact.Business.Authors.AuthorExist(buff))
                    validAuthorId = true;

                if (validAuthorId)
                {
                    _noauthorPanel.Visible = false;
                    _authorPanel.Visible = true;
                }
                else
                {
                    _noauthorPanel.Visible = true;
                    _errorAuthorIdLbl.Text = Resources.Resources.NoAuthorSelected + "!";
                    _authorPanel.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void _authorDS_Init(object sender, EventArgs e)
        {
            string buff;
            Int64 authorId;
            bool bContinue;

            try
            {
                _authorDS.SelectParameters.Clear();

                buff = Request.QueryString["authorId"];
                bContinue = !String.IsNullOrEmpty(buff);
                if (bContinue)
                {
                    bContinue = Int64.TryParse(buff, out authorId);
                }

                if (bContinue)
                    _authorDS.SelectParameters.Add("ID", TypeCode.Int64, buff);
                else
                    _authorDS.SelectParameters.Add("ID", TypeCode.Int64, "-1");
            }
            catch (Exception)
            {
            }
        }

        protected void _authorArticleTitle_Init(object sender, EventArgs e)
        {
            string buff;
            Int64 authorId;
            bool bContinue;

            try
            {
                _articleTitles.SelectParameters.Clear();

                buff = Request.QueryString["authorId"];
                bContinue = !String.IsNullOrEmpty(buff);
                if (bContinue)
                {
                    bContinue = Int64.TryParse(buff, out authorId);
                }

                if (bContinue)
                    _articleTitles.SelectParameters.Add("authorId", TypeCode.Int64, buff);
                else
                    _articleTitles.SelectParameters.Add("authorId", TypeCode.Int64, "-1");
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
