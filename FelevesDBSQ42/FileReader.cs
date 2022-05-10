using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class FileReader
    {
        public static string SourceFolder = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "\\Sources\\");
        static public List<Teacher> TeacherReader()
        {
            string[] lines = File.ReadAllLines(SourceFolder+"TeachersDatabase.txt");
            List<Teacher> teachers = new List<Teacher>();
            for (int idx = 0; idx <lines.Length; idx++)
            {
                string[] split = lines[idx].Split(';');
                teachers.Add(new Teacher(split));
            }
            return teachers;
        }
        static public List<Course> GenerateCourses(List<Teacher> teachers)
        {
            List<Course> courses = new List<Course>();
            string[] lines = File.ReadAllLines(SourceFolder+"Subjects.txt");
            List<TimeAndSpace> possibleTS = TimeTablePlanner.CreateAllRoomsAndTimes();
            foreach (Teacher teacher in teachers)
                for (int i = 0; i < teacher.NumOfCourses; i++)
                    courses.Add(new Course(teacher, lines[FindSubject(teacher.Subject, lines)].Split(';'), possibleTS));
            return courses;
            
        }
        static int FindSubject(string name,string[] lines)
        {
            int i=0;
            while (i<lines.Length && name != lines[i].Split(';')[0]) { i++;}
            if (i == lines.Length)
                throw new ArgumentException("no such subject");
            return i;
        }
        static public List<Classroom> GenerateClassrooms()
        {
            List<Classroom> classrooms = new List<Classroom>();
            string[] floors = File.ReadAllLines(SourceFolder+"School.txt");
            Array.Reverse(floors);
            for (int floor = 0; floor < floors.Length; floor++)
            {
                string[] rooms = floors[floor].Split(' ');
                for (int room = 0; room < rooms.Length; room++)
                    if (rooms[room] != "x")
                        classrooms.Add(new Classroom(rooms[room][0], floor, room));
            }
            return classrooms;
        }
        
    }
}
