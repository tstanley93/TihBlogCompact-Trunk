using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.OleDb;
using TihBlogCompact.Core;
using System.Collections.Generic;

namespace TihBlogCompact.Data.Tables
{
    public class TableArticles
    {
        #region Private Members

        private const string _TABLE_NAME = "Articles";
        private const string _COL1 = "ID"; // Long Integer, Increment
        private const string _COL2 = "title"; // Text
        private const string _COL3 = "authorId"; // Number
        private const string _COL4 = "published"; // Date/Time
        private const string _COL5 = "allowComments"; // Number
        private const string _COL6 = "content"; // Memo
        private const string _COL7 = "rating"; // Number
        private const string _SELECT_COL2_BY_COL1 = "SELECT [" + _COL2 +
                                                   "] FROM [" + _TABLE_NAME + 
                                                   "] WHERE [" + _COL1 + "]=@" + _COL1;
        private const string _SELECT_COUNT_BY_COL1 = "SELECT COUNT(*) " +
                                                  "FROM [" + _TABLE_NAME +
                                                "] WHERE [" + _COL1 + "]=@" + _COL1;
        private const string _SELECT_COUNT = "SELECT COUNT(*) " +
                                             "FROM [" + _TABLE_NAME + "]";
        private const string _INSERT_COMMAND = "INSERT INTO [" + _TABLE_NAME + "] ([" +
             _COL2 + "], [" + _COL3 + "], [" + _COL4 + "], [" + _COL5 + "], [" + _COL6 + "]) VALUES (@" +
             _COL2 + ", @" + _COL3 + ", NOW(), @" + _COL5 + ", @" + _COL6 + ")"; 
        private const string _SELECT_COL4 = "SELECT [" + _COL4 + "] " +
                                            "FROM [" + _TABLE_NAME + "] " +
                                            "ORDER BY [" + _COL4 + "]";
        private const string _UPDATE_RATING = "UPDATE [" + _TABLE_NAME + "] SET [" + _COL7 + "]=@" + _COL7 + " WHERE [" + _COL1 + "]=@" + _COL1;
        private const string _SELECT_ARTICLES = "SELECT [" + _COL1 + "], [" + _COL2 + "], MID([" + _COL6 + "], 1, 1000) AS SubContent FROM [" + _TABLE_NAME + "] ORDER BY [" + _COL4 + "] DESC";
        private const string _SELECT_IDENTITY = "SELECT @@Identity";
        private const string Select_Article_Title = "SELECT [" + _COL2 + "] FROM [" + _TABLE_NAME + "] WHERE [" + _COL4 + "]=";

        #endregion

        #region Public Delegates

        public delegate string StringModifier(string aTxt);

        #endregion

        #region Public Methods

        public static string ReadTitle(Int64 aArticleId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            string result = "";

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COL2_BY_COL1, dbConnection);

                dbCommand.Parameters.Add("@" + _COL1, OleDbType.BigInt).Value = aArticleId;

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    if (dbReader.Read())
                    {
                        if (dbReader[_COL2] != null)
                            result = dbReader[_COL2].ToString();
                    }
                }
                finally
                {
                    dbConnection.Close();
                    dbReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static int GetCount(Int64 aArticleId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            object obj;
            string buff;
            int result = 0;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COUNT_BY_COL1, dbConnection);

                dbCommand.Parameters.Add("@" + _COL1, OleDbType.VarChar).Value = aArticleId;

                dbConnection.Open();

                try
                {
                    obj = dbCommand.ExecuteScalar();
                    buff = obj.ToString();

                    Int32.TryParse(buff, out result);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static int GetCount()
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            object obj;
            string buff;
            int result = 0;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COUNT, dbConnection);

                dbConnection.Open();

                try
                {
                    obj = dbCommand.ExecuteScalar();
                    buff = obj.ToString();

                    Int32.TryParse(buff, out result);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static int Insert(string aTitle, Int64 aAuthorId, int aAllowComments, string aContent, out Int64 aID)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_INSERT_COMMAND, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aTitle;
                dbCommand.Parameters.Add("@" + _COL3, OleDbType.BigInt).Value = aAuthorId;
                dbCommand.Parameters.Add("@" + _COL5, OleDbType.SmallInt).Value = aAllowComments;
                dbCommand.Parameters.Add("@" + _COL6, OleDbType.VarWChar).Value = aContent;

                dbConnection.Open();

                try
                {
                    result = dbCommand.ExecuteNonQuery();

                    dbCommand.CommandText = _SELECT_IDENTITY;
                    aID = Int64.Parse(dbCommand.ExecuteScalar().ToString());
                }
                finally
                {
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public static List<DateTime> ReadAllPublished()
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            List<DateTime> result = new List<DateTime>(30);
            DateTime dateTime;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COL4, dbConnection);

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    while (dbReader.Read())
                    {
                        if (dbReader[_COL4] != null && DateTime.TryParse(dbReader[_COL4].ToString(), out dateTime))
                        {
                            result.Add(dateTime);
                        }
                    }
                }
                finally
                {
                    dbConnection.Close();
                    dbReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static int UpdateRating(double aRating, Int64 aArticleId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_UPDATE_RATING, dbConnection);

                dbCommand.Parameters.Add("@" + _COL7, OleDbType.Double).Value = aRating;
                dbCommand.Parameters.Add("@" + _COL1, OleDbType.BigInt).Value = aArticleId;

                dbConnection.Open();

                try
                {
                    result = dbCommand.ExecuteNonQuery();
                }
                finally
                {
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public static List<Dictionary<string, string>> GetArticles(int aCount, StringModifier aStringModifier)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>(aCount);
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_ARTICLES, dbConnection);

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    while (dbReader.Read())
                    {
                        Dictionary<string, string> articleNode = new Dictionary<string, string>(3);

                        // get article's ID 
                        if (dbReader[_COL1] != null)
                            articleNode.Add("ID", dbReader[_COL1].ToString());

                        // get article's title
                        if (dbReader[_COL1] != null)
                            articleNode.Add("Title", dbReader[_COL2].ToString());

                        // get article's mid of MID(Content, 1, 1000)
                        if (dbReader["SubContent"] != null)
                            articleNode.Add("Content", aStringModifier(dbReader["SubContent"].ToString()));

                        result.Add(articleNode);
                    }
                }
                finally
                {
                    dbConnection.Close();
                    dbReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static string GetArticleTitleByDate(DateTime ArticleDate)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            object obj;
            string result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(Select_Article_Title + "#" +  ArticleDate + "#", dbConnection);

                dbConnection.Open();

                try
                {
                    obj = dbCommand.ExecuteScalar();
                    result = obj.ToString();

                    //Int32.TryParse(buff, out result);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }

        #endregion
    }
}
