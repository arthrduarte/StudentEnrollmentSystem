using lab8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                studentDropdownError.Visible = false;
                LoadStudents();
                List<Course> courses = Helper.GetAvailableCourses();

                foreach (Course course in courses)
                {
                    ListItem courseInfo = new ListItem($"{course.Title} - {course.WeeklyHours} hours/week", course.Code);
                    
                    availableCoursesList.Items.Add(courseInfo);
                }
            }
        }
        protected void LoadStudents()
        {
            if (Session["studentList"] != null)
            {
                studentDropdownList.Items.Clear();

                studentDropdownList.Items.Add(new ListItem("Select a student...", ""));

                List<Student> studentList = (List<Student>)Session["studentList"];

                foreach (Student student in studentList)
                {
                    ListItem listItem = new ListItem(student.ToString(), student.Id.ToString()); 
                    studentDropdownList.Items.Add(listItem);
                }
            }
        }

        protected Student SelectedStudent()
        {
            int studentId = int.Parse(studentDropdownList.SelectedValue);
            List<Student> students = (List<Student>)Session["studentList"];
            Student selectedStudent = students.FirstOrDefault(s => s.Id == studentId);

            return selectedStudent;
        }

        protected void CheckboxCourses(Student selectedStudent)
        {
            foreach (ListItem listItem in availableCoursesList.Items)
            {
                listItem.Selected = false;

                foreach (Course course in selectedStudent.RegisteredCourses)
                {
                    if (listItem.Value == course.Code)
                    {
                        listItem.Selected = true;
                        break;
                    }
                }
            }
        }

        protected void StudentDropdownDifferentSelection(object sender, EventArgs e)
        {
            if (studentDropdownList.SelectedIndex > 0)
            {
                Student selectedStudent = SelectedStudent();

                if (selectedStudent != null)
                {
                    int totalCourses = selectedStudent.RegisteredCourses.Count;
                    int totalHours = selectedStudent.TotalWeeklyHours();

                    CheckboxCourses(selectedStudent);
                    selectedCoursesInfo.Visible = true;
                    selectedCoursesInfo.CssClass = "valid";
                    selectedCoursesInfo.Text = $"{selectedStudent.Name} is registered in {totalCourses} course{(totalCourses == 1 ? "" : "s")}, {totalHours} hours weekly.";
                }
            }
        }

        protected List<Course> GetSelectedCourses()
        {
            List<Course> selectedCourses = new List<Course>();
            List<Course> courses = Helper.GetAvailableCourses();

            foreach (ListItem item in availableCoursesList.Items)
            {
                if (item.Selected)
                {
                    foreach (Course course in courses)
                    {
                        if (course.Code == item.Value)
                        {
                            selectedCourses.Add(course);
                        }
                    }
                }
            }
            return selectedCourses;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            studentDropdownError.Visible = false;
            bool anyCourseSelected = false;
            foreach (ListItem item in availableCoursesList.Items)
            {
                if (item.Selected)
                {
                    anyCourseSelected = true;
                    break; 
                }
            }

            if (studentDropdownList.SelectedIndex == 0)
            {
                studentDropdownError.Visible = true;
                return;
            } else if (!anyCourseSelected)
            {
                selectedCoursesInfo.Visible = true;
                selectedCoursesInfo.Text = "You must select a course";
                selectedCoursesInfo.CssClass = "error";
            } else
            {
                Student selectedStudent = SelectedStudent();
                List<Course> selectedCourses = GetSelectedCourses();

                try
                {

                selectedStudent.RegisterCourses(selectedCourses);

                int totalHours = selectedCourses.Sum(course => course.WeeklyHours);
                
                selectedCoursesInfo.Visible = true;
                studentDropdownError.Visible = false;
                selectedCoursesInfo.CssClass = "valid";
                CheckboxCourses(selectedStudent);

                selectedCoursesInfo.Text = $"{selectedStudent.Name} has registered {selectedCourses.Count} course(s), {totalHours} hours weekly";

                } catch (Exception ex)
                {
                    selectedCoursesInfo.Visible = true;
                    selectedCoursesInfo.CssClass = "error";
                    selectedCoursesInfo.Text = ex.Message;
                }

                
            }
        }
    }
}