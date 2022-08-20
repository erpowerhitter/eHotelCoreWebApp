using DotNetCore.Domain.Domain;

using eService.Domain.Model;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eService.API.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(CurrentLoginUser userModel, AppSettings _appSettings)
        {
            return "";
        }
    }
}
