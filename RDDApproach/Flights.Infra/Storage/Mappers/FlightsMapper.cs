using Flights.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class FlightsMapper : EntityTypeConfiguration<Flight>
    {
        public FlightsMapper()
        {
            ToTable("Flights");

            Property(f => f.Id).HasColumnName("Id");
			Property(f => f.DepartureId).HasColumnName("FromId");
			Property(f => f.DestinationId).HasColumnName("ToId");
			HasRequired<Plane>(f => f.Plane).WithMany().HasForeignKey(f => f.PlaneId);
			HasRequired<Airport>(f => f.Departure).WithMany().HasForeignKey(f => f.DepartureId);
			HasRequired<Airport>(f => f.Destination).WithMany().HasForeignKey(f => f.DestinationId);

			Ignore(f => f.Name);
		}
	}
}
