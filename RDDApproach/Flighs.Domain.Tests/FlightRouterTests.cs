using Flights.Domain;
using Flights.Domain.Models;
using Moq;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Flighs.Domain.Tests
{
    public class FlightRouterTests
	{
		[Fact]
		public void Router_Should_Keep_Lat_When_Only_Long_Changes()
		{
			var from = new GPSPoint(new LatCoordinate(48), new LongCoordinate(1));
			var to = new GPSPoint(new LatCoordinate(48), new LongCoordinate(10));
			var router = new FlightRouter(from, to, 800);

			Thread.Sleep(1000);

			var location = router.CurrentLocation;
		}
	}
}
