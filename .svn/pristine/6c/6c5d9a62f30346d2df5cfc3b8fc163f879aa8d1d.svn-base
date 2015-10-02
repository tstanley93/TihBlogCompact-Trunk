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
using System.Collections.Generic;
using TihBlogCompact.Core;

namespace TihBlogCompact.Business
{
    public class Articles
    {
        #region Public Methods

        public static int GetCommentsCountForArticle(string aArticleId)
        {
            int result = 0;
            Int64 articleId;

            try
            {
                if (Int64.TryParse(aArticleId, out articleId))
                {
                    result = TableComments.GetCount(articleId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static string GetArticleTitle(string aArticleId)
        {
            string result = "";
            Int64 articleId;

            try
            {
                if (Int64.TryParse(aArticleId, out articleId))
                {
                    result = TableArticles.ReadTitle(articleId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static string GetArticleTitleByDate(DateTime TitleDate)
        {            
            string result = null;

            try
            {
                result = TableArticles.GetArticleTitleByDate(TitleDate);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static bool ArticleExist(string aArticleId)
        {
            bool result = false;
            Int64 articleId;

            try
            {
                if (Int64.TryParse(aArticleId, out articleId))
                    result = (TableArticles.GetCount(articleId) == 1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public static void AddNewArticle(string aTitle, string aContent, string aUserName, bool aAllowComments, bool aToAllCategories, List<string> aCategoriesIDs)
        {
            Int64 authorId, articleId, categoryId;
            int rowAffected;
            string buff;
            int allowComments = aAllowComments ? 1 : 0;

            #region Check Parameters

            if (String.IsNullOrEmpty(aTitle))
                throw new Exception("Title is empty or null");

            if (String.IsNullOrEmpty(aContent))
                throw new Exception("Content is empty or null");

            if (String.IsNullOrEmpty(aUserName))
                throw new Exception("UserName is empty or null");

            #endregion

            try
            {
                buff = TableAuthors.ReadID(aUserName);
                if (String.IsNullOrEmpty(buff) || !Int64.TryParse(buff, out authorId))
                    throw new Exception("authorId is null");

                // insert article in Articles table
                rowAffected = TableArticles.Insert(aTitle, authorId, allowComments, aContent, out articleId);
                if (rowAffected != 1)
                    throw new Exception("No row was inserted!");

                // add categories
                if (aToAllCategories)
                {
                    // if new article is in all categories, we insert one row in ArticleCategories with category id - 1
                    TableArticleCategories.Insert(articleId, 1);
                }
                else
                {
                    foreach (string item in aCategoriesIDs)
                    {
                        if (Int64.TryParse(item, out categoryId))
                            TableArticleCategories.Insert(articleId, categoryId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetTotalArticlesCount()
        {
            string result = "";
            int count;

            try
            {
                count = TableArticles.GetCount();
                result = count.ToString();
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static List<DateTime> GetAllArticlesPublishedDates()
        {
            List<DateTime> result = null;

            try
            {
                result = TableArticles.ReadAllPublished();
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static void AddNewComment(string aArticleId, string aNames, string aEmail, string aWebSite, string aComment, string aCountry, int aRating)
        {
            Int64 articleId;
            int rowAffected;

            #region Check Parameters

            if (!Int64.TryParse(aArticleId, out articleId))
                throw new Exception("No articleId specified");

            if (String.IsNullOrEmpty(aNames))
                throw new Exception("Name is empty or null");

            if (String.IsNullOrEmpty(aEmail))
                throw new Exception("Email is empty or null");

            if (String.IsNullOrEmpty(aComment))
                throw new Exception("Comment is empty or null");

            #endregion

            try
            {
                rowAffected = TableComments.Insert(articleId, aNames, aEmail, aWebSite, aComment, aCountry, aRating);
                if (rowAffected != 1)
                    throw new Exception("No row was inserted!");

                // if rank is set, update article's rating
                if (aRating > 0)
                    CalculateArticleRating(aArticleId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetTotalCommentsCount()
        {
            string result = "";
            int count;

            try
            {
                count = TableComments.GetCount();
                result = count.ToString();
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static string GetLastComment()
        {
            string result = "";

            try
            {
                result = TableComments.ReadMaxPublished();
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static void DeleteArticlesComments(string aArticleId)
        {
            Int64 articleId;

            try
            {
                if (Int64.TryParse(aArticleId, out articleId))
                {
                    TableComments.Delete(articleId);
                }
            }
            catch (Exception)
            { 
            }
        }

        public static void CalculateArticleRating(string aArticleId)
        {
            Int64 articleId;
            double rating;

            try
            {
                if (Int64.TryParse(aArticleId, out articleId))
                {
                    rating = TableComments.SelectAVG(articleId);

                    TableArticles.UpdateRating(rating, articleId);
                }
            }
            catch (Exception)
            {
            }
        }

        public static bool ArticleCategoryExist(string aCategory)
        {
            bool result = false;
            int count;

            if (string.IsNullOrEmpty(aCategory))
                return false;

            try
            {
                count = TableCategory.GetCount(aCategory);

                result = (count >= 1);
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static bool ArticleCategoryExist(string aCategory, string aDifferID)
        {
            bool result = false;
            Int64 id;
            int count;

            try
            {
                if (!string.IsNullOrEmpty(aCategory) && Int64.TryParse(aDifferID, out id))
                {
                    count = TableCategory.GetCount(aCategory, id);

                    result = (count >= 1);
                }
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static void AddNewArticleCategory(string aCategory, bool checkExisting)
        {
            try
            {
                if (string.IsNullOrEmpty(aCategory))
                    throw new Exception("Invalid aCategory");

                if (checkExisting && ArticleCategoryExist(aCategory))
                    throw new Exception("aCategory already exist");

                TableCategory.Insert(aCategory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool ArticlesExistsInCategory(string aCategoryId)
        {
            bool result = true;
            Int64 categoryId;
            int count;

            try
            {
                if (Int64.TryParse(aCategoryId, out categoryId))
                {
                    count = TableArticleCategories.GetCount(categoryId);

                    result = (count >= 1);
                }
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static List<Dictionary<string, string>> GetArticlesCategories(string aArticleId)
        {
            Int64 articleId;
            List<Dictionary<string, string>> result = null;

            try
            {
                if (Int64.TryParse(aArticleId, out articleId))
                {
                    result = TableArticleCategories.ReadCategories(articleId);
                }
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static List<string> GetArticleCategoriesId(string aArticleId)
        {
            List<string> result = null;
            Int64 articleId;

            try
            {
                if (Int64.TryParse(aArticleId, out articleId))
                {
                    result = TableArticleCategories.ReadCategoriesShort(articleId);
                }
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static void DeleteArticleCategory(string aArticleId, string aCategoryId)
        {
            Int64 articleId, categoryId;

            if (Int64.TryParse(aArticleId, out articleId) && Int64.TryParse(aCategoryId, out categoryId))
            {
                TableArticleCategories.Delete(articleId, categoryId);
            }
        }

        public static void UpdateArticles(bool aNewAllGroups, List<string> aNewIds, string aArticleId)
        {
            Int64 articleId, id;
            List<string> oldIds, allCategories;
            string category;
            bool inOld, inNew;

            if (!Int64.TryParse(aArticleId, out articleId))
                throw new Exception("Cannot parse aArticleId!");

            if (aNewIds == null && !aNewAllGroups)
                throw new Exception("Invalid parameter: aNewIds!");

            try
            {
                oldIds = TableArticleCategories.ReadCategoriesShort(articleId);

                if (oldIds == null)
                    throw new Exception("oldIds == null");

                // if old categories are for all
                if (oldIds.Count == 1 && oldIds[0].Equals("1"))
                {
                    // new categories are for all
                    if (aNewAllGroups)
                    {
                        // don't do nothing
                    }
                    else // new categories are custom
                    {
                        if (aNewIds.Count > 0)
                        { 
                            // delete all row in ArticleCategories
                            TableArticleCategories.Delete(articleId, 1);

                            // insert new categories
                            for (int i = 0; i < aNewIds.Count; ++i)
                            {
                                if (Int64.TryParse(aNewIds[i], out id))
                                    TableArticleCategories.Insert(articleId, id);
                            }
                        }
                    }
                }
                else // old categories are custom
                {
                    // new categories are for all
                    if (aNewAllGroups)
                    {
                        // delete all old custom categories
                        TableArticleCategories.Delete(articleId);

                        // insert row for all categories
                        TableArticleCategories.Insert(articleId, 1);
                    }
                    else
                    {
                        allCategories = TableCategory.ReadCategoriesShort();
                        
                        TbComparer tbComparer = new TbComparer();

                        // iterate through all categories
                        for (int i = 0; i < allCategories.Count; ++i)
                        {
                            category = allCategories[i];

                            inOld = oldIds.BinarySearch(category, tbComparer) >= 0;
                            inNew = aNewIds.BinarySearch(category, tbComparer) >= 0;

                            if (inOld && !inNew)
                            { 
                                // delete the category
                                TableArticleCategories.Delete(articleId, Int64.Parse(category));
                            }
                            else if (!inOld && inNew)
                            {
                                // add the category
                                TableArticleCategories.Insert(articleId, Int64.Parse(category));
                            }
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
