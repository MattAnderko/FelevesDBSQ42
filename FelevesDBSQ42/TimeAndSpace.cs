using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class TimeAndSpace
    {
        public Classroom Where { get; }
        public TimeInterval When { get; }
        public TimeAndSpace(Classroom Where, TimeInterval When)
        {
            this.Where = Where;
            this.When = When;   
        }
    }
}
