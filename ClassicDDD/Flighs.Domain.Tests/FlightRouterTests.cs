using Flights.Domain;
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
			var router = new FlightRouter(from, to, 80000);

			Thread.Sleep(3000);

			var location = router.CurrentLocation;

			Assert.Equal(48, location.LatCoordinate.Value);
			Assert.True(location.LongCoordinate.Value > 9 && location.LongCoordinate.Value < 10); //Between 9 and 10
		}
	}
}
