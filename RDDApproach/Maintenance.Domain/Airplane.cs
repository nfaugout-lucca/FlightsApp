using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class Aircraft
    {
        public IEnumerable<Seat> Seats { get; }
    }
}
