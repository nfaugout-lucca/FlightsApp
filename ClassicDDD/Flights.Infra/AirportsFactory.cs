using Flights.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
	public class AirportsFactory
	{
		public static Airport Build(AirportData airport)
		{
			var location = new GPSPoint(
				new LatCoordinate(airport.Lat),
				new LongCoordinate(airport.Long)
			);

			return new Airport(airport.Name, location);
		}
	}
}
