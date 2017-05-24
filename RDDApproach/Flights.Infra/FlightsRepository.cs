using Flights.Domain;
using Flights.Domain.Events;
using RDD.Infra.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class FlightsRepository : IRepository<Flight>
    {
		public IEnumerable<Flight> QueryEntities(Func<IQueryable<Flight>, IEnumerable<Flight>> transformation)
		{
			using (var context = new FlightsContext())
			{
				return transformation(context.Set<Flight>()
					.Include(f => f.Departure)
					.Include(f => f.Destination)
					.Include(f => f.Plane)
					.Include(f => f.Plane.Positions));
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
			using (var context = new FlightsContext())
			{
				context.Entry(flight).State = EntityState.Modified;

				context.SaveChanges();
			}
		}
	}
}
