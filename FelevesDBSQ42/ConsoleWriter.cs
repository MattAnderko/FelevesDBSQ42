using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class ConsoleWriter
    {
        public static void WriteTimeTableOf(Teacher teacher, List<Course> courses, TimeAndSpace[] ts)
        {
            Classroom[,] timetable = teacher.GetTimeTable(courses, ts);
            Console.WriteLine(teacher);
            WriteHeader();
            for (int x = 0; x < timetable.GetLength(0); x++)
            {
                Console.Write($" {x + 1} ");
                for (int y = 0; y < timetable.GetLength(1); y++)
                    if (timetable[x, y] == null)
                        Console.Write("|       ");
                    else
                        Console.Write("|  " + timetable[x, y] + "  ");
                Console.WriteLine("|");
            }
            Console.WriteLine();
        }
        static void WriteHeader()
        {
            Console.Write("   ");
            for (int i = 0; i < Program.LessonsADay; i++)
                Console.Write("________");
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < Program.LessonsADay; i++)
            {
                Console.Write($"\\");
                NumLengthToSpace(i + 1, 1);
                Console.Write($"{i + 1}.óra ");
            }
            Console.Write($"\\      ");
            Console.WriteLine();


        }
        static void NumLengthToSpace(int num, int max)
        {
            for (int i = 0; i < max - Math.Log10(num); i++)
                Console.Write(" ");
        }
    }
}
