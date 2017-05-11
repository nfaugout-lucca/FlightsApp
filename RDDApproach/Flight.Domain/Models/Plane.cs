using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Flights.Domain
{
    public class Plane : Entity
    {
		public const string EVENT_LOCATION_CHANGED = "Plane.LocationChanged";
		internal const int SPEED = 20000; //in km/h
		internal const int SLEEP_INTERVAL = 500; //in ms

		internal ICollection<PlanePosition> Positions { get; private set; }

		public GPSPoint CurrentLocation
		{
			get
			{
				var position = Positions.OrderBy(p => p.RecordedAt).LastOrDefault();
				return new GPSPoint(new LatCoordinate(position.Lat), new LongCoordinate(position.Long));
			}
		}

		public Plane()
		{
			Positions = new HashSet<PlanePosition>();
		}

		public Plane(Guid id, GPSPoint location)
			: this()
		{
			Id = id;
			Positions.Add(new PlanePosition(id, location));
		}
    }
}
