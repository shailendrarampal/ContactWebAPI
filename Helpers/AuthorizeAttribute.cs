using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ContactWebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserEntity) context.HttpContext.Items["User"];
            if (user == default)
            {
                context.Result = new JsonResult(new {Message = "UnAuthorized"})
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };}
            
        }
    }
}
