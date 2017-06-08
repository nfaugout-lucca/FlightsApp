using Flights.Domain;
using Flights.Domain.Events;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
	public class FlightsRepository : IFlightsRepository
	{
		public IEnumerable<Flight> GetFlights()
		{
			using (var context = new FlightsContext("data source=localhost;initial catalog=FLIGHTS;integrated security=False;User id=flights;Password=flights;multipleactiveresultsets=True;App=EntityFramework&quot;"))
			{
				return context.Set<FlightData>()
					.Include(f => f.From)
					.Include(f => f.To)
					.Include(f => f.Plane)
					.Include(f => f.Plane.Positions)
					.ToList()
					.Select(f => new Flight(f.Id, AirportsFactory.Build(f.From), AirportsFactory.Build(f.To), PlanesFactory.Build(f.Plane), f.DepartedAt, f.ArrivedAt));
			}
		}

		public Flight GetFlightById(Guid id)
		{
			using (var context = new FlightsContext("data source=localhost;initial catalog=FLIGHTS;integrated security=False;User id=flights;Password=flights;multipleactiveresultsets=True;App=EntityFramework&quot;"))
			{
				var flightDal = context.Set<FlightData>()
					.Include(f => f.From)
					.Include(f => f.To)
					.Include(f => f.Plane)
					.Include(f => f.Plane.Positions)
					.FirstOrDefault(f => f.Id == id);

				return new Flight(flightDal.Id, AirportsFactory.Build(flightDal.From), AirportsFactory.Build(flightDal.To), PlanesFactory.Build(flightDal.Plane), flightDal.DepartedAt, flightDal.ArrivedAt);
			}
		}

		public void ProcessEvent(Event @event)
		{
			switch(@event.Type)
			{
				case Flight.EVENT_FLIGHT_CHANGED:
					{
						FlightChanged((Flight)@event.Subject);
						break;
					}
			}
		}

		private void FlightChanged(Flight flight)
		{
			using (var context = new FlightsContext("data source=localhost;initial catalog=FLIGHTS;integrated security=False;User id=flights;Password=flights;multipleactiveresultsets=True;App=EntityFramework&quot;"))
			{
				var flightDal = context.Set<FlightData>()
					.FirstOrDefault(f => f.Id == flight.Id);

				flightDal.DepartedAt = flight.DepartedAt;
				flightDal.ArrivedAt = flight.ArrivedAt;

				context.SaveChanges();
			}
		}
	}
}
