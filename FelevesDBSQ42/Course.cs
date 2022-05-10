using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class Course
    {
        public List<TimeAndSpace> EligibleTimeAndSpace { get; }
        public Teacher Teacher { get; }
        public bool NeedsComputers { get; }
        public bool NeedsProjector { get; }
        public Course(Teacher Teacher, string[] datas, List<TimeAndSpace> possibleTS)
        {
            this.Teacher = Teacher;
            NeedsComputers = datas.Contains("computers") ? true : false;
            NeedsProjector = datas.Contains("projector") ? true : false;
            EligibleTimeAndSpace = SearchForEligible(possibleTS);
            
        }
        List<TimeAndSpace> SearchForEligible(List<TimeAndSpace> possibleTS)
        {
            List<TimeAndSpace> eligibleTS=new List<TimeAndSpace>();
            foreach(TimeAndSpace timeAndSpace in possibleTS)
                if(CanBeUsed(timeAndSpace))
                    eligibleTS.Add(timeAndSpace);
            return eligibleTS;
        }
        bool CanBeUsed(TimeAndSpace ts)
        {
            if (NeedsComputers)
                if (!ts.Where.HasComputers)
                    return false;
            if (NeedsProjector)
                if (!ts.Where.HasProjector)
                    return false;
            return true;
        }
    }
}
