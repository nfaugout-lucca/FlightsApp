using Flights.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class FlightsContext : DbContext
    {
		public FlightsContext()
			: this("data source=localhost;initial catalog=FLIGHTS;integrated security=False;User id=flights;Password=flights;multipleactiveresultsets=True;App=EntityFramework&quot;") { }

		public FlightsContext(string cName) : base(cName) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new FlightsMapper());
			modelBuilder.Configurations.Add(new AirportsMapper());
			modelBuilder.Configurations.Add(new PlanesMapper());
			modelBuilder.Configurations.Add(new PlanePositionsMapper());

			modelBuilder.ComplexType<GPSPoint>();
			modelBuilder.ComplexType<LatCoordinate>();
			modelBuilder.ComplexType<LongCoordinate>();
		}
	}
}
