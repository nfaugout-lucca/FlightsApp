using Flights.Domain;
using Flights.Domain.Events;
using Flights.Infra;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RDD.Domain;
using RDD.Infra.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Flights.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
		public static Container DIContainer = new Container();

		protected void Application_Start()
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

			DIContainer.Register<IEventDispatcher>(() => new EventDispatcher(), Lifestyle.Singleton);

			var dispatcher = DIContainer.GetInstance<IEventDispatcher>();
			dispatcher.RegisterListener(Plane.EVENT_LOCATION_CHANGED, new PlanePositionsRepository().ProcessEvent);
			dispatcher.RegisterListener(Flight.EVENT_FLIGHT_CHANGED, new FlightsRepository().ProcessEvent);
		}
	}
}
