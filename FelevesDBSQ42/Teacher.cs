using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class Teacher
    {
        public string Name { get; }
        public string Subject { get; }
        public TimeInterval[] HadABreak = new TimeInterval[Program.DaysOfWork];
        public int NumOfCourses { get; }

        public Teacher(string[] datas)
        {
            Name = datas[0];
            Subject = datas[1]; 
            NumOfCourses=int.Parse(datas[2]);
        }
        public Classroom[,] GetTimeTable(List<Course> courses, TimeAndSpace[] ts)
        {
            Classroom[,] timetable = new Classroom[Program.DaysOfWork, Program.LessonsADay];
            for (int i = 0; i < courses.Count; i++)
                if (courses[i].Teacher.Equals(this))
                    timetable[ts[i].When.Day, ts[i].When.NthInterval] = ts[i].Where;
            return timetable;
        }
        public override string ToString()
        {
            return Name + " " + Subject + "bol tart kurzusokat:";
        }
    }
}
