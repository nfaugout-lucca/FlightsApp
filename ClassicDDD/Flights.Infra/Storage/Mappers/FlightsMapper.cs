using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class FlightsMapper : EntityTypeConfiguration<FlightDal>
    {
        public FlightsMapper()
        {
            ToTable("Flights");

            Property(f => f.Id).HasColumnName("Id");
			HasRequired<PlaneDal>(f => f.Plane).WithMany().HasForeignKey(f => f.PlaneId);
			HasRequired<AirportDal>(f => f.From).WithMany().HasForeignKey(f => f.FromId);
			HasRequired<AirportDal>(f => f.To).WithMany().HasForeignKey(f => f.ToId);
		}
	}
}
