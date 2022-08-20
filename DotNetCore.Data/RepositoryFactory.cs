using DotNetCore.Domain.Domain;
using eService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace eService.Data
{
    public class RepositoryFactory
    {
        private static  AppSettings _appSettings;

        public RepositoryFactory(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        

        public static IDbConnection getConnection()
        {
            return new System.Data.SqlClient.SqlConnection(_appSettings.DbConnection);
        }
    }
}
