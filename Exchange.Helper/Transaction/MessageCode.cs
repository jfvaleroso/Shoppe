﻿namespace Exchange.Helper.Transaction
{
    public class MessageCode
    {
        #region Message Code

        public static string saved = "Successfully saved!";
        public static string modified = "Successfully modified!";
        public static string deleted = "Successfully deleted!";
        public static string error = "An error has occured";
        public static string existed = "Item already exists";
        public static string valid = "Item is valid.";
        public static string empty = "Item is empty.";
        public static string unavailable = "Code is unavailable";

        #endregion Message Code

        #region Message

        public static string GetMessage(string code)
        {
            if (code.Equals(StatusCode.saved))
            {
                return saved;
            }
            if (code.Equals(StatusCode.modified))
            {
                return modified;
            }
            return string.Empty;
        }

        #endregion Message
    }
}