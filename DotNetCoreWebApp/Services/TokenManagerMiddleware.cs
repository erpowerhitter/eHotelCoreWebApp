using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace eService.API.Services
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly ITokenManager _tokenManager;

        public TokenManagerMiddleware(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            
        }
    }
}
