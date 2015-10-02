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

namespace TihBlogCompact
{
    public class TableCategory
    {
        #region Private Members

        private const string _TABLE_NAME = "Category";
        private const string _COL1 = "ID"; // Long Integer, Increment
        private const string _COL2 = "categoryName"; // Text, Lenght: 50
        private const string _SELECT_COUNT = "SELECT COUNT(*) " +
                                             "FROM [" + _TABLE_NAME + "]";
        private const string _SELECT_COUNT_BY_COL2 = "SELECT COUNT(*) " +
                                                     "FROM [" + _TABLE_NAME + "] " +
                                                     "WHERE [" + _COL2 + "]=@" + _COL2;
        private const string _SELECT_COUNT_BY_COLS_2_DIFF_1 = "SELECT COUNT(*) " +
                                                              "FROM [" + _TABLE_NAME + "] " + 
                                                              "WHERE [" + _COL2 + "]=@" + _COL2 + " AND [" + _COL1 + "]<>@" + _COL1;
        private const string _SELECT_COL1 = "SELECT [" + _COL1 + "] " +
                                            "FROM [" + _TABLE_NAME + "] " +
                                            "ORDER BY [" + _COL1 + "]";
        private const string _SELECT_COL2_BY_COL1 = "SELECT [" + _COL2 + "] " +
                                                    "FROM [" + _TABLE_NAME + "] " +
                                                    "WHERE [" + _COL1 + "]=@" + _COL1;
        private const string _INSERT_COMMAND = "INSERT INTO [" + _TABLE_NAME + "] ([" + _COL2 + "]) VALUES (@" + _COL2 + ")";

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

        public static int GetCount(string aCategoryName)
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

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aCategoryName;

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

        public static int GetCount(string aCategoryName, Int64 aID)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            object obj;
            string buff;
            int result = 0;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COUNT_BY_COLS_2_DIFF_1, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aCategoryName;
                dbCommand.Parameters.Add("@" + _COL1, OleDbType.Integer).Value = aID;

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

        public static int Insert(string aCategoryName)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_INSERT_COMMAND, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aCategoryName;

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

        public static List<string> ReadCategoriesShort()
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            List<string> result = new List<string>(10);

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COL1, dbConnection);

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    while (dbReader.Read())
                    {
                        if (dbReader[_COL1] != null)
                        {
                            result.Add(dbReader[_COL1].ToString());
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

        public static bool ReadCategory(Int64 aCategoryID, out string aCategoryName)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            bool result = false;
            aCategoryName = null;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COL2_BY_COL1, dbConnection);

                dbCommand.Parameters.Add("@" + _COL1, OleDbType.BigInt).Value = aCategoryID;

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    if (dbReader.Read())
                    {
                        if (dbReader[_COL2] != null)
                        {
                            aCategoryName = dbReader[_COL2].ToString();
                            result = true;
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

        #endregion
    }
}
