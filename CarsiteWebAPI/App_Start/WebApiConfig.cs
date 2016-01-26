using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CarsiteWebAPI.App_Start;
using System.Web.Configuration;

namespace CarsiteWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API configuration and services
            var clientID = WebConfigurationManager.AppSettings["auth0:ClientId"];
            var clientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];

            config.MessageHandlers.Add(new JsonWebTokenValidationHandler()
            {
                Audience = clientID,
                SymmetricKey = clientSecret
            });

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "WithActionApi",
                routeTemplate: "api/{controller}/{action}/{fillupId}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
