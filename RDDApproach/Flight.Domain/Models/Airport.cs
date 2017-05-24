using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
    public class Airport : Entity
    {
        public GPSPoint Location { get; private set; }

		private Airport() { }
		public Airport(string name, GPSPoint location)
        {
            Name = name;
            Location = location;
        }
    }
}
