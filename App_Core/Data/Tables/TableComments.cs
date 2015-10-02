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
using System.Text;
using System.Collections.Generic;
using TihBlogCompact.Core;

namespace TihBlogCompact.Data.Tables
{
    public class TableComments
    {
        #region Private Members

        private const string _TABLE_NAME = "Comments";
        private const string _COL1 = "ID"; // Long Integer, Increment
        private const string _COL2 = "articleId"; // Number
        private const string _COL3 = "names"; // Text
        private const string _COL4 = "email"; // Text
        private const string _COL5 = "website"; // Text
        private const string _COL6 = "comment"; // Memo
        private const string _COL7 = "published"; // Date/Time
        private const string _COL8 = "country"; // Text
        private const string _COL9 = "rating"; // Number
        private const string _SELECT_COUNT = "SELECT COUNT(*) FROM [" + _TABLE_NAME + "]";
        private const string _SELECT_COUNT_BY_COL2 = "SELECT COUNT(*) FROM [" + _TABLE_NAME + "] WHERE [" + _COL2 + "]=@" + _COL2;
        private const string _INSERT_COMMAND = "INSERT INTO [" + _TABLE_NAME + "] ([" + _COL2 + "], [" + _COL3 + "], [" + _COL4 + "], [" + _COL5 + "], [" + _COL6 + "], [" + _COL8 + "], [" + _COL9 + "]) VALUES (" +
                                "@" + _COL2 + ", @" + _COL3 + ", @" + _COL4 + ", @" + _COL5 + ", @" + _COL6 + ", @" + _COL8 + ", @" + _COL9 + ") ";
        private const string _SELECT_LAST = "SELECT MAX(" + _COL7 + ") AS " + _COL7 + " FROM [" + _TABLE_NAME + "]";
        private const string _DELEET_BY_COL2 = "DELETE FROM [" + _TABLE_NAME + "] WHERE [" + _COL2 + "]=@" + _COL2;
        private const string _SELECT_AVG = "SELECT AVG ([" + _COL9 + "]) FROM [" + _TABLE_NAME + "] WHERE [" + _COL2 + "]=@" + _COL2 + " AND [" + _COL9 + "] <> -1";
        private const string _SELECT_COMMENTS = "SELECT [" + _COL3 + "], [" + _COL7 + "], MID([" + _COL6 + "], 1, 1000) AS SubContent FROM [" + _TABLE_NAME + "] WHERE [" + _COL2 + "]=@" + _COL2 + " ORDER BY [" + _COL7 + "] DESC";

        #endregion

        #region Public Delegates

        public delegate string StringModifier(string aTxt);

        #endregion

        #region Public Methods

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
                dbCommand = new OleDbCommand(_SELECT_COUNT_BY_COL2, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.BigInt).Value = aArticleId;

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

        public static int Insert(Int64 aArticleId, string aNames, string aEmail, string aWebSite, string aComment, string aCountry, int aRating)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_INSERT_COMMAND, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.BigInt).Value = aArticleId;
                dbCommand.Parameters.Add("@" + _COL3, OleDbType.VarWChar).Value = aNames;
                dbCommand.Parameters.Add("@" + _COL4, OleDbType.VarWChar).Value = aEmail;
                dbCommand.Parameters.Add("@" + _COL5, OleDbType.VarWChar).Value = aWebSite;
                dbCommand.Parameters.Add("@" + _COL6, OleDbType.VarWChar).Value = aComment;
                dbCommand.Parameters.Add("@" + _COL8, OleDbType.VarWChar).Value = aCountry;
                dbCommand.Parameters.Add("@" + _COL9, OleDbType.Integer).Value = aRating;

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
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static string ReadMaxPublished()
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            string result = "";

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_LAST, dbConnection);

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    if (dbReader.Read())
                    {
                        if (dbReader[_COL7] != null)
                            result = dbReader[_COL7].ToString();
                    }
                }
                finally
                {
                    dbConnection.Close();
                    dbReader.Close();
                }
            }
            catch (Exception)
            {
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
                dbCommand = new OleDbCommand(_DELEET_BY_COL2, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.BigInt).Value = aArticleId;
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
                throw new Exception(ex.ToString());
            }

            return result;
        }

        public static double SelectAVG(Int64 aArticleId)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            object obj;
            string buff;
            double result = 0;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_AVG, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.BigInt).Value = aArticleId;

                dbConnection.Open();

                try
                {
                    obj = dbCommand.ExecuteScalar();
                    buff = obj.ToString();

                    Double.TryParse(buff, out result);
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

        public static List<Dictionary<string, string>> GetComments(int aCount, Int64 aArticleId, StringModifier aStringModifier)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>(aCount);
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COMMENTS, dbConnection);

                dbCommand.Parameters.Add(_COL2, OleDbType.BigInt).Value = aArticleId;

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    while (dbReader.Read())
                    {
                        Dictionary<string, string> commentNode = new Dictionary<string, string>(3);

                        // get comment's names 
                        if (dbReader[_COL3] != null)
                            commentNode.Add("names", dbReader[_COL3].ToString());

                        // get comment's published
                        if (dbReader[_COL7] != null)
                            commentNode.Add("published", dbReader[_COL7].ToString());

                        // get comment's mid of MID(Comment, 1, 1000)
                        if (dbReader["SubContent"] != null)
                            commentNode.Add("Comment", aStringModifier(dbReader["SubContent"].ToString()));

                        result.Add(commentNode);
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

        #endregion
    }
}
