using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Flights.Infra
{
	public class PlaneData
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<PlanePositionData> Positions { get; set; }

		public PlaneData()
		{
			Positions = new HashSet<PlanePositionData>();
		}
	}
}