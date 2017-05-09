using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class PlanesMapper : EntityTypeConfiguration<PlaneDal>
    {
        public PlanesMapper()
        {
            ToTable("Planes");

            Property(p => p.Id).HasColumnName("Id");
			HasMany<PlanePositionDal>(p => p.Positions).WithRequired().HasForeignKey(pp => pp.PlaneId);
        }
    }
}
