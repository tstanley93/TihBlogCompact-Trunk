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
using TihBlogCompact.Core;

namespace TihBlogCompact.Data.Tables
{
    public class TableLinks
    {
        #region Private Members

        private const string _TABLE_NAME = "Links";
        private const string _COL1 = "ID"; // Long Integer, Increment
        private const string _COL2 = "URL"; // Text, Lenght: 200
        private const string _COL3 = "urlText"; // Text, Lenght: 200
        private const string _INSERT = "INSERT INTO [" + _TABLE_NAME + "] " +
                                       "([" + _COL2 + "], [" + _COL3 + "]) VALUES " +
                                       "(@" + _COL2 + ", @" + _COL3 + ")";

        #endregion

        #region Public Methods

        public static int Insert(string aURL, string aUrlText)
        {
            OleDbConnection dbConnection;
            OleDbCommand dbCommand;
            int result;

            try
            {
                dbConnection = new OleDbConnection(ConnectionStringsManager.GetConnectionString());
                dbCommand = new OleDbCommand(_INSERT, dbConnection);

                dbCommand.Parameters.Add("@" + _COL2, OleDbType.VarWChar).Value = aURL;
                dbCommand.Parameters.Add("@" + _COL3, OleDbType.VarWChar).Value = aUrlText;

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

        #endregion
    }
}
