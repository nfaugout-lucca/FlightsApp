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
		private const int SPEED = 20000; //in km/h
		private const int SLEEP_INTERVAL = 500; //in ms

		public GPSPoint CurrentLocation { get; private set; }

        public Plane(Guid id, GPSPoint location)
        {
			Id = id;
			CurrentLocation = location;
        }

        internal void FlyThrough(IEventDispatcher dispatcher,  GPSPoint destination)
        {
            var router = new FlightRouter(CurrentLocation, destination, SPEED);

            for (var i=0; i < 100; i++)
            {
                CurrentLocation = router.CurrentLocation;
				dispatcher.RaiseEvent(new Event(EVENT_LOCATION_CHANGED, this));

                Thread.Sleep(SLEEP_INTERVAL);

				//After sleep router is still at the same location ?
				//If so, means that the fly is over
				if (router.CurrentLocation == CurrentLocation)
				{
					break;
				}
            }
        }

		internal void ResetLocation(IEventDispatcher dispatcher, GPSPoint location)
		{
			CurrentLocation = location;
			dispatcher.RaiseEvent(new Event(EVENT_LOCATION_CHANGED, this));
		}
    }
}
