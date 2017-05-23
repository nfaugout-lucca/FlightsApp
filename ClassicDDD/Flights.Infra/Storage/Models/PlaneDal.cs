using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Flights.Infra
{
	public class PlaneDal
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<PlanePositionDal> Positions { get; set; }

		public PlaneDal()
		{
			Positions = new HashSet<PlanePositionDal>();
		}
	}
}