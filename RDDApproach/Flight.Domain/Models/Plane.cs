using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Flights.Domain.Events;

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

		internal void FlyThrough(IEventDispatcher dispatcher, GPSPoint destination)
		{
			var router = new FlightRouter(CurrentLocation, destination, SPEED);

			for (var i = 0; i < 100; i++)
			{
				var position = new PlanePosition(Id, router.CurrentLocation);
				Positions.Add(position);
				dispatcher.RaiseEvent(new Event(EVENT_LOCATION_CHANGED, position));

				Thread.Sleep(SLEEP_INTERVAL);

				//After sleep router is still at the same location ?
				//If so, means that the fly is over
				if (router.CurrentLocation.Equals(CurrentLocation))
				{
					break;
				}
			}
		}

		internal void ResetLocation(IEventDispatcher dispatcher, GPSPoint location)
		{
			var position = new PlanePosition(Id, location);
			Positions.Add(position);
			dispatcher.RaiseEvent(new Event(EVENT_LOCATION_CHANGED, position));
		}
	}
}
