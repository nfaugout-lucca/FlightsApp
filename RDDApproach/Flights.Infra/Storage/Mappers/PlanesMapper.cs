using Flights.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class PlanesMapper : EntityTypeConfiguration<Plane>
    {
        public PlanesMapper()
        {
            ToTable("Planes");

            Property(p => p.Id).HasColumnName("Id");
			HasMany<PlanePosition>(p => p.Positions).WithRequired().HasForeignKey(pp => pp.PlaneId);
        }
    }
}
