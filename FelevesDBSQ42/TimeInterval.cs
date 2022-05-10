using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class TimeInterval
    {
        public int Day { get; }
        public int NthInterval { get; }
        public TimeInterval(int Day, int NthInterval)
        {
            this.Day = Day;
            this.NthInterval = NthInterval;
        }
    }

}
