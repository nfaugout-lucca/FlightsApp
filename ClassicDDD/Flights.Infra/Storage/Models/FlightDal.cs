using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class FlightDal
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
		public Guid FromId { get; set; }
		public AirportDal From { get; set; }
		public Guid ToId { get; set; }
		public AirportDal To { get; set; }
		public Guid PlaneId { get; set; }
		public PlaneDal Plane { get; set; }
		public DateTime? DepartedAt { get; set; }
		public DateTime? ArrivedAt { get; set; }
	}
}
