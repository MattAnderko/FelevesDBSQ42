using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class TimeTablePlanner
    {
        static public TimeAndSpace[] GenerateTimeTable(List<Course> courses)
        {
            List<TimeAndSpace>[] R = new List<TimeAndSpace>[courses.Count];
            for (int i = 0; i < courses.Count; i++)
                R[i] = courses[i].EligibleTimeAndSpace;
            TimeAndSpace[] e = new TimeAndSpace[courses.Count];
            bool exists = false;
            BTS(R, 0, e, courses, ref exists);
            return e;
        }
        static void BTS(List<TimeAndSpace>[] R, int level, TimeAndSpace[] e, List<Course> courses, ref bool exists)
        {
            int i = -1;
            while (!exists && i < R[level].Count - 1)
            {
                i++;
                if (eFK(level, R[level][i], e, courses))
                {
                    e[level] = R[level][i];
                    if (level == R.Length - 1)
                        exists = true;
                    else
                        BTS(R, level + 1, e, courses, ref exists);
                }
            }
        }
        static bool eFK(int level, TimeAndSpace ts, TimeAndSpace[] e, List<Course> courses)
        {
            int[] teacherLessonPerDay = new int[Program.DaysOfWork];
            for (int i = 0; i < level; i++)
            {
                if (e[i] == ts)
                    return false;
                if (courses[i].Teacher == courses[level].Teacher)
                {
                    if (e[i].When == ts.When)
                        return false;
                    teacherLessonPerDay[e[i].When.Day]++;
                }
                if (teacherLessonPerDay[e[i].When.Day] == 8)
                    return false;
                if (teacherLessonPerDay[ts.When.Day] == 6 && courses[level].Teacher.HadABreak[ts.When.Day] == null)
                {
                    courses[level].Teacher.HadABreak[ts.When.Day] = ts.When;
                    return false;
                }
                if (courses[level].Teacher.HadABreak[ts.When.Day] == ts.When)
                    return false;
            }
            return true;
        }
        static List<TimeInterval> timeIntervalsCreator()
        {
            List<TimeInterval> intervals = new List<TimeInterval>();
            for (int i = 0; i < Program.DaysOfWork; i++)
                for (int interval = 0; interval < Program.LessonsADay; interval++)
                    intervals.Add(new TimeInterval(i, interval));
            return intervals;
        }
        public static List<TimeAndSpace> CreateAllRoomsAndTimes()
        {
            List<TimeAndSpace> tSPairs = new List<TimeAndSpace>();
            List<TimeInterval> intervals = timeIntervalsCreator();
            List<Classroom> classrooms = FileReader.GenerateClassrooms();
            foreach (Classroom classroom in classrooms)
                foreach (TimeInterval interval in intervals)
                    tSPairs.Add(new TimeAndSpace(classroom, interval));
            return tSPairs;
        }
    }
}
