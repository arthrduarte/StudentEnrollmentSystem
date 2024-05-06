using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name) : base(name)
        {

        }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = selectedCourses.Sum(course => course.WeeklyHours);
            if (totalHours > MaxWeeklyHours)
            {
                throw new Exception("Total weekly hours exceed the maximum allowed for Co-op students: 4");
            }

            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception("Number of courses exceed the maximum allowed for Co-op students: 2");
            }

            base.RegisterCourses(selectedCourses);
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Coop)";
        }
    }
}