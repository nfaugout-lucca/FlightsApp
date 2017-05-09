using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class AirportDal
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Lat { get; set; }
		public decimal Long { get; set; }
    }
}
