using Flights.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
	public interface IEventDispatcher
	{
		void RegisterListener(string eventType, Action<Event> callback);
		void RaiseEvent(Event @event);
	}
}
