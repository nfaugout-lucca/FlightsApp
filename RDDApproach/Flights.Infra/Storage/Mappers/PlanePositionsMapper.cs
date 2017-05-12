using Flights.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
    public class PlanePositionsMapper : EntityTypeConfiguration<PlanePosition>
    {
        public PlanePositionsMapper()
        {
            ToTable("PlanePositions");

			Property(pp => pp.Id).HasColumnName("Id");
			Ignore(pp => pp.Name);
		}
	}
}
