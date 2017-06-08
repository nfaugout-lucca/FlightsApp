using Flights.Domain;
using Flights.Domain.Events;
using Flights.Domain.Models;
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
				case Travel.EVENT_TRAVEL_CREATED:
					{
						TravelCreated((Travel)@event.Subject);
						break;
					}

				case FlightReset.EVENT_RESET_CREATED:
					{
						ResetCreated((FlightReset)@event.Subject);
						break;
					}
			}
		}

		private void TravelCreated(Travel travel)
		{
			using (var context = new FlightsContext())
			{
				context.Entry(travel.Flight).State = EntityState.Modified;

				context.SaveChanges();
			}
		}

		private void ResetCreated(FlightReset reset)
		{
			using (var context = new FlightsContext())
			{
				context.Entry(reset.Flight).State = EntityState.Modified;

				context.SaveChanges();
			}
		}
	}
}
