using DotNetCore.Domain.Domain;
using eService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace eService.Common.Constants
{
    /// <summary>
    /// This class holds various application constant values.
    /// </summary>
    public static class AppConstants
    {
        public static AppSettings _appSettings;
        public static void SetUtilityConfiguration(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }     

        public class APIResponseMessage
        {
            public const string Unauthorized = "You are unauthorized to access the requested resource. Please log in.";
            public const string ErrorMessage = "Sorry, something went wrong. Please try again after sometime. If the issue still persists contact support.";
        }       

        public const string AppUserId = "AppUserId";
        public const string Email = "Email";
        public const string AccessToken = "access_token";
        public const string RefreshAccessToken = "refresh_token";
        public const string TokenExpiresAt = "expires_at";

    }
}

