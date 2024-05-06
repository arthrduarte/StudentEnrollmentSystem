using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class Student
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public List<Course> RegisteredCourses { get; }

        public Student(string name)
        {
            this.Name = name;

            Random random = new Random();
            Id = random.Next(90000, 99999);

            RegisteredCourses = new List<Course>();
        }
        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();

            foreach(Course course in selectedCourses)
            {
                RegisteredCourses.Add(course);
            }
        }
        public int TotalWeeklyHours()
        {
            int hoursCounter = 0;

            foreach(Course course in RegisteredCourses)
            {
                hoursCounter += course.WeeklyHours;
            }
            return hoursCounter;
        }
    }
}