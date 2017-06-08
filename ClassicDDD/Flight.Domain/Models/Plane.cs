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
		private const int SPEED = 27600; //in km/h
		private const int SLEEP_INTERVAL = 100; //in ms

		public GPSPoint CurrentLocation { get; private set; }

		public Plane(Guid id, GPSPoint location)
		{
			Id = id;
			CurrentLocation = location;
		}

		internal void FlyThrough(IEventDispatcher dispatcher,  GPSPoint destination)
		{
			var router = new FlightRouter(CurrentLocation, destination, SPEED);

			while (!router.CurrentLocation.Equals(CurrentLocation))
			{
				CurrentLocation = router.CurrentLocation;
				dispatcher.RaiseEvent(new Event(EVENT_LOCATION_CHANGED, this));

				Thread.Sleep(SLEEP_INTERVAL);
			}
		}

		internal void ResetLocation(IEventDispatcher dispatcher, GPSPoint location)
		{
			CurrentLocation = location;
			dispatcher.RaiseEvent(new Event(EVENT_LOCATION_CHANGED, this));
		}
	}
}
