using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
using System.Net;
using System.Text;
using Loot_Lo_API.Models;

namespace Loot_Lo_API
{
    public class BasicAuthenticationAttribute 
        //: AuthorizationFilterAttribute
    { 

        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    if(actionContext.Request.Headers.Authorization == null)
        //    {
        //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //    }

        //    else
        //    {
        //        string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
        //        string decodeAuthenticationToken = Encoding.UTF8.GetString(
        //            Convert.FromBase64String(authenticationToken));
        //        string[] usernamePasswordArray = decodeAuthenticationToken.Split(':');
        //        string userEmail = usernamePasswordArray[0];
        //        string password = usernamePasswordArray[1];

        //        if(!AdminSecurity.Login(userEmail, password))
        //        {
        //            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        }
        //    }
        //}
    }
}
