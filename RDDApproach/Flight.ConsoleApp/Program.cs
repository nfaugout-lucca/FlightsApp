using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flights.Domain;

namespace Flights.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			var plane = new Plane(new PlanePositionsRepository(), new SeatClassesDescriptor { BusinessClassSeats = 10, FirstClassSeats = 10, SecondClassSeats = 30 }, FlightPhase.Stopped, null);

            var airport1 = new Airport("LAX", new GPSPoint(new LatCoordinate(33.942809M), new LongCoordinate(-118.404706M)));
            var airport2 = new Airport("PAR", new GPSPoint(new LatCoordinate(49.0083899664M), new LongCoordinate(2.53844117956M)));

            var flight = new Flight(Guid.Empty, airport1, airport2, plane, DateTime.Now, null);
            flight.Start();
        }
    }
}
