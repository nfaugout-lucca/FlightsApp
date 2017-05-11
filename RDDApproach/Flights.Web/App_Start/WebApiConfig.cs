using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Flights.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "Start flights",
				routeTemplate: "api/{controller}/{id}/start",
				defaults: new
				{
					id = RouteParameter.Optional,
					controller = "FlightsController",
					action = "Start"
				}
			);

			config.Routes.MapHttpRoute(
				name: "Reset flights",
				routeTemplate: "api/{controller}/{id}/reset",
				defaults: new
				{
					id = RouteParameter.Optional,
					controller = "FlightsController",
					action = "Reset"
				}
			);

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
