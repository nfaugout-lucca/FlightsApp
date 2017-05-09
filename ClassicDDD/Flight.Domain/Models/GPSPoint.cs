using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
    public class GPSPoint
    {
        public LatCoordinate LatCoordinate { get; private set; }
        public LongCoordinate LongCoordinate { get; private set; }

        public GPSPoint(LatCoordinate latCoordinate, LongCoordinate longCoordinate)
        {
            LatCoordinate = latCoordinate;
            LongCoordinate = longCoordinate;
        }
    }

    public class LatCoordinate
    {
        public decimal Value { get; private set; }

        public LatCoordinate(decimal coordinate)
        {
            Value = coordinate;
        }
    }

    public class LongCoordinate
    {
        public decimal Value { get; private set; }

        public LongCoordinate(decimal coordinate)
        {
            Value = coordinate;
        }
    }
}
