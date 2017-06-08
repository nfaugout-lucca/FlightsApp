using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Flights.Domain.Events;

namespace Flights.Domain.Models
{
    public class Plane : Entity
    {
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
		public Plane(Guid id)
			: this()
		{
			Id = id;
		}

		internal void FlyThrough(IEventDispatcher dispatcher, GPSPoint destination)
		{
			var router = new FlightRouter(CurrentLocation, destination, SPEED);

			while (!router.CurrentLocation.Equals(CurrentLocation))
			{
				new PlanePosition(this, router.CurrentLocation, dispatcher);

				Thread.Sleep(SLEEP_INTERVAL);
			}
		}

		internal void ResetLocation(IEventDispatcher dispatcher, GPSPoint location)
		{
			new PlanePosition(this, location, dispatcher);
		}
	}
}
