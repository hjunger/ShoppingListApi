using ShoppingListApi.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ShoppingListApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", 
                new { id = RouteParameter.Optional }, new { id = @"\d+" });
            config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}", 
                new { action = RouteParameter.Optional });


            config.Filters.Add(new ShoppingListAuthorizeAttribute());

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
