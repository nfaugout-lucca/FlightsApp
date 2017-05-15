using Flights.Domain.Events;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
	public class Flight : Entity
	{
		public const string EVENT_FLIGHT_CHANGED = "Flight.Changed";

		public Airport Departure { get; private set; }
		public Airport Destination { get; private set; }
		public Plane Plane { get; private set; }
		public DateTime? DepartedAt { get; private set; }
		public DateTime? ArrivedAt { get; private set; }

		public bool IsPlaneFlying
		{
			get
			{
				return DepartedAt.HasValue && !ArrivedAt.HasValue;
			}
		}

		public Flight(Airport departure, Airport destination, Plane plane, DateTime? departedAt, DateTime? arrivedAt)
			: this(Guid.NewGuid(), departure, destination, plane, departedAt, arrivedAt) { }

		public Flight(Guid id, Airport departure, Airport destination, Plane plane, DateTime? departedAt, DateTime? arrivedAt)
		{
			Id = id;
			Departure = departure;
			Destination = destination;
			Plane = plane;
			DepartedAt = departedAt;
			ArrivedAt = arrivedAt;
		}

        public void Start(IEventDispatcher dispatcher)
        {
			DepartedAt = DateTime.Now;
			ArrivedAt = null;
			dispatcher.RaiseEvent(new Event(EVENT_FLIGHT_CHANGED, this));

            Plane.FlyThrough(dispatcher, Destination.Location);

			ArrivedAt = DateTime.Now;
			dispatcher.RaiseEvent(new Event(EVENT_FLIGHT_CHANGED, this));
		}

		public void Reset(IEventDispatcher dispatcher)
		{
			DepartedAt = null;
			ArrivedAt = null;
			dispatcher.RaiseEvent(new Event(EVENT_FLIGHT_CHANGED, this));

			Plane.ResetLocation(dispatcher, Departure.Location);
		}
	}
}
