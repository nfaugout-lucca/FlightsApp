using Flights.Domain;
using Flights.Infra;
using Flights.Web.Models;
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
        public IEnumerable<FlightDto> Get()
        {
            var repo = new FlightsRepository();
            var flights = repo.GetFlights();

			return flights
				.Select(f => new FlightDto
				{
					Id = f.Id,
					IsPlaneFlying = f.IsPlaneFlying,
					Lat = f.Plane.CurrentLocation.LatCoordinate.Value,
					Long = f.Plane.CurrentLocation.LongCoordinate.Value,
				});
        }

		// GET api/flights/{id}
		public FlightDto Get(Guid id)
		{
			var repo = new FlightsRepository();
			var flight = repo.GetFlightById(id);

			return new FlightDto
			{
				Id = flight.Id,
				IsPlaneFlying = flight.IsPlaneFlying,
				Lat = flight.Plane.CurrentLocation.LatCoordinate.Value,
				Long = flight.Plane.CurrentLocation.LongCoordinate.Value,
			};
		}

		// POST api/flights/{id}/start
		[HttpPost]
        public void Start(Guid id)
        {
			var repo = new FlightsRepository();
			var flights = repo.GetFlights();

			var flight = flights.FirstOrDefault(f => f.Id == id);
			if (flight != null)
			{
				Task.Run(() => flight.Start(WebApiApplication.DIContainer.GetInstance<IEventDispatcher>()));
			}
		}

		// POST api/flights/{id}/reset
		[HttpPost]
		public void Reset(Guid id)
		{
			var repo = new FlightsRepository();
			var flights = repo.GetFlights();

			var flight = flights.FirstOrDefault(f => f.Id == id);
			if (flight != null)
			{
				flight.Reset(WebApiApplication.DIContainer.GetInstance<IEventDispatcher>());
			}
		}
	}
}
