using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
	public class FlightsMapper : EntityTypeConfiguration<FlightData>
	{
		public FlightsMapper()
		{
			ToTable("Flights");

			Property(f => f.Id).HasColumnName("Id");
			HasRequired<PlaneData>(f => f.Plane).WithMany().HasForeignKey(f => f.PlaneId);
			HasRequired<AirportData>(f => f.From).WithMany().HasForeignKey(f => f.FromId);
			HasRequired<AirportData>(f => f.To).WithMany().HasForeignKey(f => f.ToId);
		}
	}
}
