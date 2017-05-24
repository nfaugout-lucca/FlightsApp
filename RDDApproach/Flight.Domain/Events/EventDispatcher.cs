using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain.Events
{
	public class EventDispatcher : IEventDispatcher
	{
		private Dictionary<string, List<Action<Event>>> _callbacks;

		public EventDispatcher()
		{
			_callbacks = new Dictionary<string, List<Action<Event>>>();
		}

		public void RegisterListener(string eventType, Action<Event> callback)
		{
			//First listener
			if (!_callbacks.ContainsKey(eventType))
			{
				_callbacks[eventType] = new List<Action<Event>>();
			}

			_callbacks[eventType].Add(callback);
		}

		public void RaiseEvent(Event @event)
		{
			//If any listener
			if (_callbacks.ContainsKey(@event.Type))
			{
				foreach(var callback in _callbacks[@event.Type])
				{
					callback(@event);
				}
			}
		}
	}
}
