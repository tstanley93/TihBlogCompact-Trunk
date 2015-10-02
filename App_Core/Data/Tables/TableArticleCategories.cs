using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections.Generic;
using TihBlogCompact.Core;

namespace TihBlogCompact.Data.Tables
{
    public class TableArticleCategories
    {
        #region Private Members

        private const string _TABLE_NAME = "ArticleCategories";
        private const string _COL1 = "articleId"; // Long Integer
        private const string _COL2 = "categoryId"; // Long Integer
        private const string _SELECT_COUNT_BY_COL2 = "SELECT COUNT(*) " +
                                                     "FROM [" + _TABLE_NAME + "] " +
                                                     "WHERE [" + _COL2 + "]=@" + _COL2;
        private const string _INSERT_COMMAND = "INSERT INTO [" + _TABLE_NAME + "] ([" + _COL1 + "], [" + _COL2 + "]) VALUES (@" + _COL1 + ", @" + _COL2 + ")";
        private const string _SELECT_CATEGORIES_BY_COL1 = "SELECT C.[ID] AS cid, C.[categoryName] AS cname " +
                                                          "FROM [" + _TABLE_NAME + "] A " +
                                                          "INNER JOIN [Category] C on A.[" + _COL2 + "] = C.[ID] " +
                                                          "WHERE A.[" + _COL1 + "]=@" + _COL1 + " " +
                                                          "ORDER BY C.[ID]";
        private const string _SELECT_COL2_BY_COL1 = "SELECT [" + _COL2 + "] " +
                                                    "FROM [" + _TABLE_NAME + "] " +
                                                    "WHERE [" + _COL1 + "]=@" + _COL1 + " " +
                                                    "ORDER BY [" + _COL2 + "]";
        private const string _DELETE_BY_COL1_COL2 = "DELETE FROM [" + _TABLE_NAME + "] " +
                                                    "WHERE [" + _COL1 + "]=@" + _COL1 + " AND " +
                                                          "[" + _COL2 + "]=@" + _COL2;
        private const string _DELETE_BY_COL1 = "DELETE FROM [" + _TABLE_NAME + "] " +
                                               "WHERE [" + _COL1 + "]=@" + _COL1;

        #endregion

        #region Public Methods

        public static int GetCount(Int64 aCategoryId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            object obj;
            string buff;
            int result = 0;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COUNT_BY_COL2, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.Integer).Value = aCategoryId;

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

        public static int Insert(Int64 aArticleId, Int64 aCategoryId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_INSERT_COMMAND, dbConnection);

                dbCommand.Parameters.Add("@" + _COL1, OleDbType.BigInt).Value = aArticleId;
                dbCommand.Parameters.Add("@" + _COL2, OleDbType.BigInt).Value = aCategoryId;

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

        public static List<Dictionary<string, string>> ReadCategories(Int64 aArticleId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            List<Dictionary<string, string>> result = new List<Dictionary<string,string>>(10);
            Dictionary<string, string> dict;
            string cid, cname;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_CATEGORIES_BY_COL1, dbConnection);

                dbCommand.Parameters.Add("@" + _COL1, OleDbType.BigInt).Value = aArticleId;

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    while (dbReader.Read())
                    {
                        if (dbReader["cid"] != null && dbReader["cname"] != null)
                        {
                            cid = dbReader["cid"].ToString();
                            cname = dbReader["cname"].ToString();

                            dict = new Dictionary<string, string>(2);
                            dict.Add("id", cid);
                            dict.Add("name", cname);

                            result.Add(dict);
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

        public static List<string> ReadCategoriesShort(Int64 aArticleId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            List<string> result = new List<string>(10);

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COL2_BY_COL1, dbConnection);

                dbCommand.Parameters.Add("@" + _COL1, OleDbType.BigInt).Value = aArticleId;

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    while (dbReader.Read())
                    {
                        if (dbReader[_COL2] != null)
                        {
                            result.Add(dbReader[_COL2].ToString());
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

        public static int Delete(Int64 aArticleId, Int64 aCategoryId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_DELETE_BY_COL1_COL2, dbConnection);

                dbCommand.Parameters.Add("@" + _COL1, OleDbType.BigInt).Value = aArticleId;
                dbCommand.Parameters.Add("@" + _COL2, OleDbType.BigInt).Value = aCategoryId;

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

        public static int Delete(Int64 aArticleId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_DELETE_BY_COL1, dbConnection);

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

        #endregion
    }
}
