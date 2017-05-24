using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Infra
{
	public class AirportsMapper : EntityTypeConfiguration<AirportDal>
	{
		public AirportsMapper()
		{
			ToTable("Airports");

			Property(a => a.Id).HasColumnName("Id");
		}
	}
}
