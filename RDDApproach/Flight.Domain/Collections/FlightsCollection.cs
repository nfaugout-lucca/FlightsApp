using RDD.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain.Collections
{
	public class FlightsCollection
	{
		private IRepository<Flight> _entitySource;
		private IEventDispatcher _dispatcher;

		public FlightsCollection(IRepository<Flight> entitySource, IEventDispatcher dispatcher)
		{
			_entitySource = entitySource;
			_dispatcher = dispatcher;
		}

		public IEnumerable<Flight> GetFlights()
		{
			return _entitySource.QueryEntities((flights) => flights.ToList());
		}

		public Flight GetFlightById(Guid id)
		{
			return _entitySource.QueryEntities((flights) => flights.Where(f => f.Id == id).ToList()).FirstOrDefault();
		}

		public void StartFlightById(Guid id)
		{
			var flight = GetFlightById(id);

			Task.Run(() => flight.Start(_dispatcher));
		}

		public void ResetFlightById(Guid id)
		{
			var flight = GetFlightById(id);

			flight.Reset(_dispatcher);
		}
	}
}
