using lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["studentList"] == null)
                {
                    Session["studentList"] = new List<Student>();
                }
                createStudentRow();
                studentTypeDropdown.Items[0].Attributes["disabled"] = "disabled";
                studentTypeDropdown.SelectedIndex = 0;

                studentTypeDropdownError.Visible = false;
                studentNameError.Visible = false;
                List<Student> studentList = new List<Student>();

            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            studentNameError.Visible = false;
            studentTypeDropdownError.Visible = false;


            if (studentNameBox.Text == "")
            {
                studentNameError.Visible = true;
                createStudentRow();
                return;
            }
            Student newStudent;
            List<Student> studentList = (List<Student>)Session["studentList"];
            switch (studentTypeDropdown.SelectedValue)
            {
                case "fulltime":
                    newStudent = new FulltimeStudent(studentNameBox.Text);
                    studentList.Add(newStudent);
                    createStudentRow();
                    break;
                case "parttime":
                    newStudent = new ParttimeStudent(studentNameBox.Text);
                    studentList.Add(newStudent);
                    createStudentRow();
                    break;
                case "coop":
                    newStudent = new CoopStudent(studentNameBox.Text);
                    studentList.Add(newStudent);
                    createStudentRow();
                    break;
                default:
                    studentTypeDropdownError.Visible = true;
                    createStudentRow();
                    break;
            }

            Session["studentList"] = studentList;

            studentNameBox.Text = "";
            studentTypeDropdown.SelectedIndex = 0;

        }

        protected void createStudentRow()
        {
            List<Student> studentList = (List<Student>)Session["studentList"];

            foreach (Student student in studentList)
            {
                TableRow newRow = new TableRow();
                newRow.Cells.Add(new TableCell { Text = student.Id.ToString() });
                newRow.Cells.Add(new TableCell { Text = student.Name });

                studentTable.Rows.Add(newRow);
            }

        }
    }
}