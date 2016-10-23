using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ShoppingListApi.Authorization
{

    /// <summary>
    /// Usually I would send some kind of information encrypted. The server's handler would take the value, decrypted and compare the HASH.
    /// But since this is just a local test and I wasn't sure how I should encrypt the information, I'm just comparing the two keys
    /// </summary>
    public class ShoppingListAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = string.Empty;
            var headers = actionContext.Request.Headers;
            
            if (headers.Contains("Authorization"))
            {
                token = headers.GetValues("Authorization").FirstOrDefault();
            }

            if (token == ConfigurationManager.AppSettings["SecretKey"])
                return;

            HandleUnauthorizedRequest(actionContext);
        }
    }
}