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
		private Func<IStorageService> _getStorage;

		public FlightsCollection(Func<IStorageService> getStorage)
		{
			_getStorage = getStorage;
		}

		public void Create(Flight flight)
		{
			using (var storage = _getStorage())
			{
				storage.Add(flight);
				storage.Commit();
			}
		}

		public IEnumerable<Flight> GetFlights()
		{
			using (var storage = _getStorage())
			{
				return storage.Set<Flight>()
					.Include(f => f.Departure)
					.Include(f => f.Destination)
					.Include(f => f.Plane)
					.Include(f => f.Plane.Positions)
					.ToList();
			}
		}

		private Flight GetFlightById(Guid id, IStorageService storage)
		{
			return storage.Set<Flight>()
				.Include(f => f.Departure)
				.Include(f => f.Destination)
				.Include(f => f.Plane)
				.Include(f => f.Plane.Positions)
				.FirstOrDefault(f => f.Id == id);
		}

		public Flight GetFlightById(Guid id)
		{
			using (var storage = _getStorage())
			{
				return GetFlightById(id, storage);
			}
		}

		public void StartFlight(Guid id)
		{
			Flight flight;

			using (var storage = _getStorage())
			{
				flight = GetFlightById(id, storage);
				flight.DepartedAt = DateTime.Now;
				flight.ArrivedAt = null;

				storage.Commit();
			}

			new PlanesCollection(_getStorage)
				.FlyPlaneThrough(flight.Plane, flight.Destination.Location);

			using (var storage = _getStorage())
			{
				var freshFlight = GetFlightById(id, storage);
				freshFlight.ArrivedAt = DateTime.Now;

				storage.Commit();
			}
		}

		public void ResetFlight(Guid id)
		{
			using (var storage = _getStorage())
			{
				var flight = GetFlightById(id, storage);
				flight.DepartedAt = null;
				flight.ArrivedAt = null;

				storage.Commit();

				new PlanesCollection(_getStorage)
					.ResetPlaneLocation(flight.Plane, flight.Departure.Location);
			}
		}
	}
}
