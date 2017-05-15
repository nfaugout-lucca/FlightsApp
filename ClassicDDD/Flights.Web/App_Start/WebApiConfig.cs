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
				name: "Start plane",
				routeTemplate: "api/{controller}/startPlane",
				defaults: new
				{
					id = RouteParameter.Optional,
					controller = "PlanesController",
					action = "StartPlane"
				}
			);

			config.Routes.MapHttpRoute(
				name: "Reset plane position",
				routeTemplate: "api/{controller}/resetPlanePosition",
				defaults: new
				{
					controller = "PlanesController",
					action = "ResetPlanePosition"
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
