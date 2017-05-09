using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flights.Web.Models
{
    public class FlightDto
    {
		public Guid Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public bool IsPlaneFlying { get; set; }
    }
}