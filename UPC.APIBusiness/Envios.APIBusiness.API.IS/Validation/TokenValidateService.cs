using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.IS
{

    /// <summary>
    /// 
    /// </summary>
    public class TokenValidateService : ICustomTokenRequestValidator
    {

        private readonly HttpContext _httpContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextAccessor"></param>
        public TokenValidateService(IHttpContextAccessor contextAccessor)
        {
            _httpContext = contextAccessor.HttpContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task ValidateAsync(CustomTokenRequestValidationContext context)
        {
            var userid = context.Result.ValidatedRequest.Raw.Get("client_codigo_usuario");
            var username = context.Result.ValidatedRequest.Raw.Get("client_username_usuario");
            context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
            context.Result.ValidatedRequest.ClientClaims.Add(new Claim("codigo_usuario", userid));
            context.Result.ValidatedRequest.ClientClaims.Add(new Claim("username_usuario", username));
            return Task.FromResult(0);
        }
    }
}
