using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Seat
    {
        public Grade Grade { get; private set; }

        public Seat(Grade grade)
        {
            Grade = grade;
        }
    }
}
