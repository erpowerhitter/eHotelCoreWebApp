#region Namespace

using System.Collections.Generic;

#endregion

namespace eService.Domain.Model
{
    /// <summary>
    /// Current Login User
    /// </summary>
    public class CurrentLoginUser
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string EmailAddress { get; set; }


        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it was for forget password set.
        /// /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is locked; otherwise, <c>false</c>.
        /// </value>
        public bool IsPasswordReset { get; set; }

        /// <summary>
        /// Gets or sets the country identifier for mobile.
        /// </summary>
        /// <value>
        /// The country identifier for mobile.
        /// </value>
        public long? CountryIdForMobile { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        public string Mobile { get; set; }        

        public string APIEnvironment { get; set; }

        public bool IsFeedBackAvailable { get; set; }
    }
}
