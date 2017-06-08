using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
	public class PlanesMapper : EntityTypeConfiguration<PlaneData>
	{
		public PlanesMapper()
		{
			ToTable("Planes");

			Property(p => p.Id).HasColumnName("Id");
					HasMany<PlanePositionData>(p => p.Positions).WithRequired().HasForeignKey(pp => pp.PlaneId);
		}
	}
}
