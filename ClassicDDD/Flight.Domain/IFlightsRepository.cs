using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
	public interface IFlightsRepository
	{
		IEnumerable<Flight> GetFlights();
		Flight GetFlightById(Guid id);
	}
}
