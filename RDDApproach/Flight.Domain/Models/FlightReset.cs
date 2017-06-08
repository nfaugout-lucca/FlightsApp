using Flights.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain.Models
{
	public class FlightReset : Entity
	{
		public Flight Flight { get; private set; }

		public const string EVENT_RESET_CREATED = "FlightReset.Created";

		public FlightReset(Flight flight, IEventDispatcher dispatcher)
		{
			Flight = flight;

			Flight.DepartedAt = null;
			Flight.ArrivedAt = null;

			dispatcher.RaiseEvent(new Event(EVENT_RESET_CREATED, this));
		}
	}
}