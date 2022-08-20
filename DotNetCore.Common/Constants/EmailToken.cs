using System;
using System.Collections.Generic;
using System.Text;

namespace eService.Common.Constants
{
    /// <summary>
    /// Contain all contstant which will use for Email template
    /// </summary>
    public static class EmailToken
    {
        #region Forgot Password
        /// <summary>
        /// To name
        /// </summary>
        public const string ToName = "[Name]";

        /// <summary>
        /// The user name
        /// </summary>
        public const string UserName = "[UserName]";       

        /// <summary>
        /// The refernce number
        /// </summary>
        public const string RefernceNumber = "[ReferenceNumber]";        

        /// <summary>
        /// The login URL
        /// </summary>
        public const string LoginUrl = "[ManageUrl]";

        /// <summary>
        /// The email address
        /// </summary>
        public const string EmailAddress = "[EmailAddress]";        

        #endregion
    }
}
