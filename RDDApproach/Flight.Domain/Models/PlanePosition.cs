using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
	public class PlanePosition : Entity
	{
		public Guid PlaneId { get; set; }
		public decimal Lat { get; set; }
		public decimal Long { get; set; }
		public DateTime RecordedAt { get; set; }

		private PlanePosition() { }
		public PlanePosition(Guid planeId, GPSPoint location)
		{
			Id = Guid.NewGuid();
			PlaneId = planeId;
			Lat = location.LatCoordinate.Value;
			Long = location.LongCoordinate.Value;
			RecordedAt = DateTime.Now;
		}
	}
}
