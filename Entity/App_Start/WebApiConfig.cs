using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Entity
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{chanel}/{color}",
                defaults: new { id = RouteParameter.Optional, chanel = RouteParameter.Optional, color = RouteParameter.Optional}
            );

            // Отключаем возможность вывода данных в формате XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
