using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
	public interface IRepository<TEntity>
		where TEntity : Entity
	{
		IEnumerable<TEntity> QueryEntities(Func<IQueryable<TEntity>, IEnumerable<TEntity>> transformation);
	}
}
