using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base(name)
        {

        }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = selectedCourses.Sum(course => course.WeeklyHours);
            if(totalHours > MaxWeeklyHours)
            {
                throw new Exception("Total weekly hours exceed the maximum allowed for full-time students: 16");
            }
            base.RegisterCourses(selectedCourses);

        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Full-time)";
        }
    }
}