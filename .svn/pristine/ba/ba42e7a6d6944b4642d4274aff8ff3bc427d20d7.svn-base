using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using TihBlogCompact.Data;
using TihBlogCompact.Core;

namespace TihBlogCompact.Business
{
    public class TBRssManager
    {
        public static List<Dictionary<string, string>> GetArticlesForRss()
        {
            List<Dictionary<string, string>> result = null;
            int count;

            try
            {
                count = TihBlogCompact.Data.Tables.TableArticles.GetCount();

                result = TihBlogCompact.Data.Tables.TableArticles.GetArticles(count, TBConvertor.HTMLtoPlainText);
            }
            catch (Exception)
            {
            }

            return result;
        }

        public static List<Dictionary<string, string>> GetCommentsForRss(string aArticleId)
        {
            List<Dictionary<string, string>> result = null;
            int count;
            Int64 articleId;

            try
            {
                if (string.IsNullOrEmpty(aArticleId) || !Int64.TryParse(aArticleId, out articleId))
                    throw new Exception("not valid articleId");

                count = TihBlogCompact.Data.Tables.TableComments.GetCount(articleId);

                result = TihBlogCompact.Data.Tables.TableComments.GetComments(count, articleId, TBConvertor.HTMLtoPlainText);
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
