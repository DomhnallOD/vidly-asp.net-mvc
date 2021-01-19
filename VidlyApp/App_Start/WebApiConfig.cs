using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace VidlyApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings; //Get a reference on the formatting settings for serialising to JSON
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver(); //Tell it to resolve to camelCase property names
            settings.Formatting = Newtonsoft.Json.Formatting.Indented; //And to indent nicely

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
