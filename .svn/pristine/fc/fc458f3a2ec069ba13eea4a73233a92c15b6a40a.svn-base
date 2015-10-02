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

namespace TihBlogCompact.Business
{
    public class UserManagement
    {
        public static bool IsLoginValid(string aUsername, string aPassword)
        {
            bool result = false;
            int count;
            string key, cryptedPass, decryptedPass;
           
            if (String.IsNullOrEmpty(aUsername))
                throw new Exception("aUsername is null or empty!");

            if (String.IsNullOrEmpty(aPassword))
                throw new Exception("aPassword is null or empty!");

            try
            {
                // check if user with aUsername exist
                count = TableAuthors.GetCount(aUsername);

                if (count != 1)
                    return false;

                // get key for crypt password
                key = ConfigurationManager.AppSettings["cryptKey"] as string;

                // check key
                if (String.IsNullOrEmpty(key))
                    return false;

                // read pass for user: aUsername
                cryptedPass = TableAuthors.ReadPassword(aUsername);
                
                // check if read was successful
                if (String.IsNullOrEmpty(cryptedPass))
                    return false;

                // decrypt the password
                decryptedPass = CryptText.Decrypt(cryptedPass, key);

                // compare decryptedPass and aPassword, if they match pass is correct
                if (decryptedPass.Equals(aPassword))
                    result = true;
            }
            catch (Exception)
            {
            }

            return result;
        }

        public static void ChangePassword(string aUsername, string aNewPassword)
        {
            string key, cryptedPass;

            if (String.IsNullOrEmpty(aUsername))
                throw new Exception("aUsername is null or empty!");

            if (String.IsNullOrEmpty(aNewPassword))
                throw new Exception("aPassword is null or empty!");

            try
            {
                // key key for crypt password
                key = ConfigurationManager.AppSettings["cryptKey"] as string;

                // check key
                if (String.IsNullOrEmpty(key))
                    throw new Exception("Key cannot be found!");

                // crypt new password, crypted password is saved in db
                cryptedPass = CryptText.Encrypt(aNewPassword, key);

                // check if read was successful
                if (String.IsNullOrEmpty(cryptedPass))
                    throw new Exception("password cannot be crypted!");

                // save new password to db
                TableAuthors.Update(aUsername, cryptedPass);
            }
            catch (Exception)
            {
            }
        }
    }
}
