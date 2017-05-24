using Flights.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class AirportsMapper : EntityTypeConfiguration<Airport>
    {
        public AirportsMapper()
        {
            ToTable("Airports");

			Property(a => a.Id).HasColumnName("Id");
			Property(a => a.Location.LatCoordinate.Value).HasColumnName("Lat");
			Property(a => a.Location.LongCoordinate.Value).HasColumnName("Long");
		}
	}
}
