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
    public class TableAuthors
    {
        #region Private Members

        private const string _TABLE_NAME = "Authors";
        private const string _COL1 = "ID"; // Long Integer, Increment
        private const string _COL2 = "username"; // Text
        private const string _COL3 = "password"; // Text
        private const string _COL4 = "names"; // Text
        private const string _COL5 = "resume"; // Memo
        private const string _SELECT_COUNT = "SELECT COUNT(*) " +
                                              "FROM [" + _TABLE_NAME + "]";
        private const string _SELECT_COUNT_BY_COL2 = "SELECT COUNT(*) " +
                                              "FROM [" + _TABLE_NAME +
                                              "] WHERE [" + _COL2 + "]=@" + _COL2;
        private const string _SELECT_COL3_BY_COL2 = "SELECT [" + _COL3 + "] " +
                                                 "FROM [" + _TABLE_NAME + "] " +
                                                 "WHERE [" + _COL2 + "]=@" + _COL2;
        private const string _SELECT_COL1_BY_COL2 = "SELECT [" + _COL1 + "] " +
                                                 "FROM [" + _TABLE_NAME + "] " +
                                                 "WHERE [" + _COL2 + "]=@" + _COL2;
        private const string _SELECT_COL1_COL3 = "SELECT [" + _COL1 + "], [" + _COL3 + "] " +
                                                 "FROM [" + _TABLE_NAME + "]";
        private const string _UPDATE_COL3_BY_COL2 = "UPDATE [" + _TABLE_NAME +
                                                    "] SET [" + _COL3 + "]=@" + _COL3 +
                                                    " WHERE [" + _COL2 + "]=@" + _COL2;
        private const string _UPDATE_COL3_BY_COL1 = "UPDATE [" + _TABLE_NAME +
                                                    "] SET [" + _COL3 + "]=@" + _COL3 +
                                                    " WHERE [" + _COL1 + "]=@" + _COL1;
        private const string _SELECT_COUNT_BY_COL1 = "SELECT COUNT(*) " +
                                              "FROM [" + _TABLE_NAME +
                                              "] WHERE [" + _COL1 + "]=@" + _COL1;

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
                throw new Exception(ex.Message);
            }

            return result;
        }

        public static int GetCount(string aUserName)
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

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aUserName;

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
                throw new Exception(ex.Message);
            }

            return result;
        }

        public static int GetCount(Int64 aAuthorId)
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

                dbCommand.Parameters.Add("@" + _COL1, OleDbType.VarChar).Value = aAuthorId;

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

        public static string ReadPassword(string aUserName)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            string result = null;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COL3_BY_COL2, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aUserName;

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    if (dbReader.Read())
                    {
                        if (dbReader[_COL3] != null)
                            result = dbReader[_COL3].ToString();
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

        public static string ReadID(string aUserName)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            string result = null;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COL1_BY_COL2, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aUserName;

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    if (dbReader.Read())
                    {
                        if (dbReader[_COL1] != null)
                            result = dbReader[_COL1].ToString();
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

        public static int Update(string aUserName, string aPassword)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result = 0;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_UPDATE_COL3_BY_COL2, dbConnection);

                dbCommand.Parameters.Add("@" + _COL3, OleDbType.VarWChar).Value = aPassword;
                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aUserName;

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

        public static int Update(Int64 aID, string aPassword)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result = 0;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_UPDATE_COL3_BY_COL1, dbConnection);

                dbCommand.Parameters.Add("@" + _COL3, OleDbType.VarWChar).Value = aPassword;
                dbCommand.Parameters.Add("@" + _COL1, OleDbType.BigInt).Value = aID;

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

        public static List<Dictionary<string, string>> ReadPasswords()
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            OleDbDataReader dbReader;
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>(10);
            Dictionary<string, string> dict;
            string id, password;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_SELECT_COL1_COL3, dbConnection);

                dbConnection.Open();
                dbReader = dbCommand.ExecuteReader();

                try
                {
                    while (dbReader.Read())
                    {
                        if (dbReader[_COL1] != null && dbReader[_COL3] != null)
                        {
                            id = dbReader[_COL1].ToString();
                            password = dbReader[_COL3].ToString();

                            dict = new Dictionary<string, string>(2);
                            dict.Add("id", id);
                            dict.Add("password", password);

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

        #endregion
    }
}
