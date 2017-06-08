using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Flights.Infra
{
	public class PlanePositionData
	{
		public Guid Id { get; set; }
		public Guid PlaneId { get; set; }
		public decimal Lat { get; set; }
		public decimal Long { get; set; }
		public DateTime RecordedAt { get; set; }
	}
}
