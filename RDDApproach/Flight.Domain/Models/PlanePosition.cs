using Flights.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain.Models
{
	public class PlanePosition : Entity
	{
		public const string EVENT_POSITION_CREATED = "PlanePosition.Created";

		public Guid PlaneId { get; set; }
		public Plane Plane { get; set; }
		public decimal Lat { get; set; }
		public decimal Long { get; set; }
		public DateTime RecordedAt { get; set; }

		private PlanePosition() { }
		internal PlanePosition(Plane plane, GPSPoint location)
		{
			Id = Guid.NewGuid();
			PlaneId = plane.Id;
			Plane = plane;
			Lat = location.LatCoordinate.Value;
			Long = location.LongCoordinate.Value;
			RecordedAt = DateTime.Now;
		}
		public PlanePosition(Plane plane, GPSPoint location, IEventDispatcher dispatcher)
			: this(plane, location)
		{
			plane.Positions.Add(this);

			dispatcher.RaiseEvent(new Event(EVENT_POSITION_CREATED, this));
		}
	}
}
