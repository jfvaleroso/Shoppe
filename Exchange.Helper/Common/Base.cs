using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Helper.Common
{
    public class Base
    {
        #region key generation
        public static string GenearateKey(int maxSize)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, maxSize)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result.ToString();
        }
        public static string GenearateCode(int maxSize)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, maxSize)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result.ToString();
        }
        public static string GenerateBranchCode(string key, string id)
        {

            string code = string.Format("{0}{1}", key.Replace(" ", "").Substring(0, 3).ToUpper(), id);
            return code;
        }
        #endregion
        #region Common
        public static string SearchString(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            { searchString = string.Format("{0}{1}{2}", "%", searchString, "%"); }
            return searchString.ToString();
        }
        public static string StarstWith(string searchString="")
        {
            if (!string.IsNullOrEmpty(searchString))
            { searchString = string.Format("{0}{1}",  searchString, "%"); }
            return searchString.ToString();
        }
        public static string EndsWith(string searchString = "")
        {
            if (!string.IsNullOrEmpty(searchString))
            { searchString = string.Format("{0}{1}","%", searchString); }
            return searchString.ToString();
        }
        public static string SearchAnywhere(string searchString = "")
        {
            if (!string.IsNullOrEmpty(searchString))
            { searchString = string.Format("{0}{1}{2}", "%", searchString, "%"); }
            return searchString.ToString();
        }
        #endregion
        #region Security
        public static string Encrypt(string input)
        {
            try
            {
                byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(input);
                string encryptPassword = Convert.ToBase64String(passBytes);
                return encryptPassword;
            }
            catch
            {

                return "0";
            }

        }
        public static string Decrypt(string input)
        {
            try
            {

                byte[] passByteData = Convert.FromBase64String(input);
                string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
                return originalPassword;
            }
            catch
            {
                return "0";
            }
        }
        #endregion
    }
}
