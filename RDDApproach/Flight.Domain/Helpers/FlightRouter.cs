using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain
{
    public class FlightRouter
    {
        GPSPoint _from;
        GPSPoint _to;
        GPSPoint _current;
        DateTime _start;
        int _speed; // km/hour
        const decimal latitudeToKm = 111.11M;

        public FlightRouter(GPSPoint from, GPSPoint to, int speed)
        {
            _from = _current = from;
            _to = to;
            _start = DateTime.Now;
            _speed = speed;
        }

        public GPSPoint CurrentLocation
        {
            get
            {
                var latitudeOffset = _to.LatCoordinate.Value - _from.LatCoordinate.Value;
                var longitudeOffset = _to.LongCoordinate.Value - _from.LongCoordinate.Value;

                var latitudeOffsetInKm = latitudeToKm * latitudeOffset;
                var longitudeOffsetInKm = Math.Abs(latitudeToKm * (decimal)Math.Cos((double)_from.LatCoordinate.Value));

                var totalDistance = Math.Sqrt(Math.Pow((double)latitudeOffsetInKm, 2) + Math.Pow((double)longitudeOffsetInKm, 2));

                var currentDistance = (DateTime.Now - _start).TotalHours * _speed;

                if (currentDistance >= totalDistance)
                {
                    return _to;
                }

                var ratio = currentDistance / totalDistance;

                var latitude = new LatCoordinate(_from.LatCoordinate.Value + latitudeOffset * (decimal)ratio);
                var longitude = new LongCoordinate(_from.LongCoordinate.Value + longitudeOffset * (decimal)ratio);

                return new GPSPoint(latitude, longitude);
            }
        }
    }
}
