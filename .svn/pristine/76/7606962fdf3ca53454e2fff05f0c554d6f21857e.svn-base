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
using TihBlogCompact.Data.Tables;
using TihBlogCompact.Business;

namespace TihBlogCompact.Business
{
    public class Authors
    {
        public static string GetTotalCount()
        {
            string result = "0";
            int count;

            try
            {
                count = TableAuthors.GetCount();
                result = count.ToString();
            }
            catch (Exception)
            { 
            }

            return result;
        }

        public static bool AuthorExist(string aAuthorId)
        {
            bool result = false;
            Int64 authorId;

            try
            {
                if (Int64.TryParse(aAuthorId, out authorId))
                    result = (TableAuthors.GetCount(authorId) == 1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public static void ChangeCryptKey(string aOldKey, string aNewKey)
        {
            List<Dictionary<string, string>> authorsNodes;
            Dictionary<string, string> authorNode;
            string sID, oldCryptPass, newCryptPass, password;
            Int64 id;
            int rowAffected;

            if (string.IsNullOrEmpty(aOldKey))
                throw new Exception("aOldKey is null or empty!");

            if (string.IsNullOrEmpty(aNewKey))
                throw new Exception("aNewKey is null or empty!");

            try
            {
                authorsNodes = TableAuthors.ReadPasswords();

                if (authorsNodes == null)
                    throw new Exception("authorsNodes == null");

                for (int i = 0; i < authorsNodes.Count; ++i)
                {
                    authorNode = authorsNodes[i];

                    sID = authorNode["id"];
                    oldCryptPass = authorNode["password"];
                    
                    if (!string.IsNullOrEmpty(sID) && !string.IsNullOrEmpty(oldCryptPass) && Int64.TryParse(sID, out id))
                    { 
                        // decrypt password with old key
                        password = CryptText.Decrypt(oldCryptPass, aOldKey);

                        // crypt password with new key
                        newCryptPass = CryptText.Encrypt(password, aNewKey);

                        // update new password crypted value in database
                        rowAffected = TableAuthors.Update(id, newCryptPass);

                        if (rowAffected == 0)
                            throw new Exception("No Row Affected!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
