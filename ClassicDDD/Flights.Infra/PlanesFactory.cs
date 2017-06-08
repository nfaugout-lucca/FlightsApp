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
		public static Plane Build(PlaneData plane)
		{
			var lastKnownPosition = plane.Positions.OrderBy(p => p.RecordedAt).LastOrDefault();
			var location = new GPSPoint(
				new LatCoordinate(lastKnownPosition.Lat),
				new LongCoordinate(lastKnownPosition.Long)
			);

			return new Plane(plane.Id, location);
		}
	}
}
