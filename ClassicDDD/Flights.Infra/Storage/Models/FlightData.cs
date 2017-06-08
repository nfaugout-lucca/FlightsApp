using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
	public class FlightData
	{
		public Guid Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public Guid FromId { get; set; }
		public AirportData From { get; set; }
		public Guid ToId { get; set; }
		public AirportData To { get; set; }
		public Guid PlaneId { get; set; }
		public PlaneData Plane { get; set; }
		public DateTime? DepartedAt { get; set; }
		public DateTime? ArrivedAt { get; set; }
	}
}
