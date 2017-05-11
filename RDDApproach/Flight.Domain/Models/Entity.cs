using RDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
    public abstract class Entity : IPrimaryKey
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }

		public object GetId() { return Id; }
		public void SetId(object id) { Id = (Guid)id; }
	}
}
