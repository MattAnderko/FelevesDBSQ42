using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class Program
    {
        public const int DaysOfWork = 5;
        public const int LessonsADay = 9;
        static void Main(string[] args)
        {
            List<Teacher> teachers = FileReader.TeacherReader();
            List<Course> courses = FileReader.GenerateCourses(teachers);
            TimeAndSpace[] ts = TimeTablePlanner.GenerateTimeTable(courses);
            foreach (Teacher teacher in teachers)
                ConsoleWriter.WriteTimeTableOf(teacher, courses, ts);
            Console.ReadKey();
        }

    }
}