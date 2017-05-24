using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain.Events
{
	public class Event
	{
		public string Type { get; private set; }
		public Entity Subject { get; private set; }

		public Event(string type, Entity subject)
		{
			Type = type;
			Subject = subject;
		}
	}
}
