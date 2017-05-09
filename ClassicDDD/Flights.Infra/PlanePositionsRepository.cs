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
    public class PlanePositionsRepository
	{
		public void ProcessEvent(Event @event)
		{
			switch(@event.Type)
			{
				case Plane.EVENT_LOCATION_CHANGED:
					{
						var plane = (Plane)@event.Subject;

						Add(plane, plane.CurrentLocation);

						break;
					}
				default:
					throw new NotImplementedException();
			}
		}

		private void Add(Plane plane, GPSPoint position)
		{
			using (var context = new FlightsContext("data source=localhost;initial catalog=FLIGHTS;integrated security=False;User id=flights;Password=flights;multipleactiveresultsets=True;App=EntityFramework&quot;"))
			{
				var planePositionDal = new PlanePositionDal()
				{
					Id = Guid.NewGuid(),
					Lat = position.LatCoordinate.Value,
					Long = position.LongCoordinate.Value,
					PlaneId = plane.Id,
					RecordedAt = DateTime.Now
				};

				context.Set<PlanePositionDal>()
					.Add(planePositionDal);

				context.SaveChanges();
			}
		}
	}
}
