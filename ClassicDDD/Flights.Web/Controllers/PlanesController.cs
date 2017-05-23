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
	public class PlanesController : ApiController
	{
		// GET api/planes
		public IEnumerable<PlaneDto> Get()
		{
			var repo = new FlightsRepository();
			var flights = repo.GetFlights();

			return flights
				.Select(f => new PlaneDto
				{
					Id = f.Plane.Id,
					IsFlying = f.IsPlaneFlying,
					Lat = f.Plane.CurrentLocation.LatCoordinate.Value,
					Long = f.Plane.CurrentLocation.LongCoordinate.Value,
				});
		}

		// GET api/planes/{id}
		public PlaneDto Get(Guid id)
		{
			var repo = new FlightsRepository();
			var flight = repo.GetFlights().FirstOrDefault(f => f.Plane.Id == id);

			return new PlaneDto
			{
				Id = flight.Plane.Id,
				IsFlying = flight.IsPlaneFlying,
				Lat = flight.Plane.CurrentLocation.LatCoordinate.Value,
				Long = flight.Plane.CurrentLocation.LongCoordinate.Value,
			};
		}

		// POST api/planes/startPlane
		[HttpPost]
		public void StartPlane(Guid id)
		{
			var repo = new FlightsRepository();
			var flights = repo.GetFlights();

			var flight = flights.FirstOrDefault(f => f.Plane.Id == id);
			if (flight != null)
			{
				Task.Run(() => flight.Start(WebApiApplication.DIContainer.GetInstance<IEventDispatcher>()));
			}
		}

		// POST api/planes/resetPlanePosition
		[HttpPost]
		public void ResetPlanePosition(Guid id)
		{
			var repo = new FlightsRepository();
			var flights = repo.GetFlights();

			var flight = flights.FirstOrDefault(f => f.Plane.Id == id);
			if (flight != null)
			{
				flight.Reset(WebApiApplication.DIContainer.GetInstance<IEventDispatcher>());
			}
		}
	}
}
