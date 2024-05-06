using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }

        public ParttimeStudent(string name) : base(name)
        {

        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if(selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception("Number of courses exceed the maximum allowed for part-time students: 3");
            }
            base.RegisterCourses(selectedCourses);
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Part-time)";
        }
    }
}