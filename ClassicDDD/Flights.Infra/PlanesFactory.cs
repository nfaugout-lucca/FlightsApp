using Flights.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
	public class PlanesFactory
	{
		public static Plane Build(PlaneDal plane)
		{
			var lastKnownPosition = plane.Positions.OrderBy(p => p.RecordedAt).LastOrDefault();
			var location = new Domain.GPSPoint(
				new Domain.LatCoordinate(lastKnownPosition.Lat),
				new Domain.LongCoordinate(lastKnownPosition.Long)
			);

			return new Plane(plane.Id, location);
		}
	}
}
