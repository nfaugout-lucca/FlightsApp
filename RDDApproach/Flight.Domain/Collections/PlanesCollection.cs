using RDD.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flights.Domain.Collections
{
	public class PlanesCollection
	{
		private Func<IStorageService> _getStorage;

		public PlanesCollection(Func<IStorageService> getStorage)
		{
			_getStorage = getStorage;
		}

		public void Create(Plane plane)
		{
			using (var storage = _getStorage())
			{
				storage.Add(plane);
				storage.Commit();
			}
		}

		private Plane GetPlaneById(Guid id, IStorageService storage)
		{
			return storage.Set<Plane>()
				.Include(p => p.Positions)
				.FirstOrDefault(f => f.Id == id);
		}

		public Plane GetPlaneById(Guid id)
		{
			using (var storage = _getStorage())
			{
				return GetPlaneById(id, storage);
			}
		}

		public void FlyPlaneThrough(Plane plane, GPSPoint destination)
		{
			var router = new FlightRouter(plane.CurrentLocation, destination, Plane.SPEED);

			for (var i = 0; i < 100; i++)
			{
				using (var storage = _getStorage())
				{
					var freshPlane = GetPlaneById(plane.Id, storage);
					freshPlane.Positions.Add(new PlanePosition(freshPlane.Id, router.CurrentLocation));

					storage.Commit();

					Thread.Sleep(Plane.SLEEP_INTERVAL);

					//After sleep router is still at the same location ?
					//If so, means that the fly is over
					if (router.CurrentLocation.Equals(freshPlane.CurrentLocation))
					{
						break;
					}
				}
			}
		}

		public void ResetPlaneLocation(Plane plane, GPSPoint location)
		{
			using (var storage = _getStorage())
			{
				var freshPlane = GetPlaneById(plane.Id, storage);
				freshPlane.Positions.Add(new PlanePosition(freshPlane.Id, location));

				storage.Commit();
			}
		}
	}
}
