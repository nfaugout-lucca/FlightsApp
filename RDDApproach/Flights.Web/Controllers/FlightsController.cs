using Flights.Domain;
using Flights.Domain.Collections;
using Flights.Infra;
using RDD.Domain;
using RDD.Infra.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Flights.Web.Controllers
{
    public class FlightsController : ApiController
    {
		// GET api/flights
		public IEnumerable<Flight> Get()
		{
			var collection = new FlightsCollection(() => new EFStorageService(new FlightsContext()));
			var flights = collection.GetFlights();

			return flights;
		}

		// GET api/flights/{id}
		public Flight Get(Guid id)
		{
			var collection = new FlightsCollection(() => new EFStorageService(new FlightsContext()));
			var flight = collection.GetFlightById(id);

			return flight;
		}

		// POST api/flights/{id}/start
		[HttpPost]
        public void Start(Guid id)
        {
			var collection = new FlightsCollection(() => new EFStorageService(new FlightsContext()));

			Task.Run(() => collection.StartFlight(id));
		}

		// POST api/flights/{id}/reset
		[HttpPost]
		public void Reset(Guid id)
		{
			var collection = new FlightsCollection(() => new EFStorageService(new FlightsContext()));

			collection.ResetFlight(id);
		}
	}
}
