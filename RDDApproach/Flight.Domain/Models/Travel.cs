using Flights.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain.Models
{
	public class Travel : Entity
	{
		public Flight Flight { get; private set; }

		public const string EVENT_TRAVEL_CREATED = "Travel.Created";

		public Travel(Flight flight, IEventDispatcher dispatcher)
		{
			Flight = flight;

			Flight.DepartedAt = DateTime.Now;
			Flight.ArrivedAt = null;
			dispatcher.RaiseEvent(new Event(EVENT_TRAVEL_CREATED, this));

			Flight.Plane.FlyThrough(dispatcher, Flight.Destination.Location);

			Flight.ArrivedAt = DateTime.Now;
			dispatcher.RaiseEvent(new Event(EVENT_TRAVEL_CREATED, this));
		}
	}
}
