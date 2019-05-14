using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo3B
{
    public partial class Form1 : Form
    {
        private School school = null;
        private StudentInfoModelContainer dbContext;

        public Form1()
        {
            InitializeComponent();
        }

        private void DisableEventHandlers()
        {
            this.departmentsDropDownList.SelectedValueChanged -= this.departmentsDropDownList_SelectedValueChanged;
            this.termsDropDownList.SelectedValueChanged -= this.termsDropDownList_SelectedValueChanged;
            this.coursesDropDownList.SelectedValueChanged -= this.coursesDropDownList_SelectedValueChanged;
            this.sectionsDropDownList.SelectedValueChanged -= this.sectionsDropDownList_SelectedValueChanged;
            this.enrollmentsListBox.SelectedValueChanged -= this.enrollmentsListBox_SelectedValueChanged;
            this.assignmentsListBox.SelectedValueChanged -= this.assignmentsListBox_SelectedValueChanged;
        }

        private void EnableEventHandlers()
        {
            this.departmentsDropDownList.SelectedValueChanged += new System.EventHandler(this.departmentsDropDownList_SelectedValueChanged);
            this.termsDropDownList.SelectedValueChanged += new System.EventHandler(this.termsDropDownList_SelectedValueChanged);
            this.coursesDropDownList.SelectedValueChanged += new System.EventHandler(this.coursesDropDownList_SelectedValueChanged);
            this.sectionsDropDownList.SelectedValueChanged += new System.EventHandler(this.sectionsDropDownList_SelectedValueChanged);
            this.enrollmentsListBox.SelectedValueChanged += new System.EventHandler(this.enrollmentsListBox_SelectedValueChanged);
            this.assignmentsListBox.SelectedValueChanged += new System.EventHandler(this.assignmentsListBox_SelectedValueChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DisableEventHandlers();
            this.dbContext = new StudentInfoModelContainer();
            this.school = this.dbContext.Schools.First();

            // Departments
            this.school.Departments = this.dbContext.Departments.ToList();
            this.departmentsDropDownList.DisplayMember = "DeptName";
            this.departmentsDropDownList.DataSource = this.school.Departments;
            Department comc = this.school.FindDepartment("COMC");
            this.departmentsDropDownList.SelectedItem = comc;

            //Courses
            comc.Courses = this.dbContext.Courses.Where(c =>
                c.Department.Id == comc.Id).ToList();
            this.coursesDropDownList.DisplayMember = "CourseTitle";
            this.coursesDropDownList.DataSource = comc.Courses;
            Course comc2750 = comc.FindCourse("2750");
            this.coursesDropDownList.SelectedItem = comc2750;

            this.school.Terms = this.dbContext.Terms.ToList();
            this.termsDropDownList.DisplayMember = "DisplayString";
            this.termsDropDownList.DataSource = this.school.Terms;
            Term spr2020 = this.school.FindTerm(2020, TermsEnum.Spr);
            this.termsDropDownList.SelectedItem = spr2020;

            //Sections
            comc2750.Sections = this.dbContext.Sections.Where(s =>
                s.Course.Id == comc2750.Id &&
                s.Term.Id == spr2020.Id).ToList();
            this.sectionsDropDownList.DisplayMember = "Id";
            this.sectionsDropDownList.DataSource = comc2750.Sections;
            Section sect2750 = comc2750.Sections.Last();
            this.sectionsDropDownList.SelectedItem = sect2750;

            //Assignments
            sect2750.Assignments = this.dbContext.Assignments.Where(a =>
                a.Section.Id == comc2750.Id).ToList();
            this.assignmentsListBox.DisplayMember = "DisplayString";
            this.assignmentsListBox.DataSource = sect2750.Assignments;

            //Enrollments
            sect2750.Enrollments = this.dbContext.Enrollments.Include("Student").Where(enr =>
                enr.Section.Id == sect2750.Id).ToList();
            this.enrollmentsListBox.DisplayMember = "DisplayString";
            this.enrollmentsListBox.DataSource = sect2750.Enrollments;
            
            //Grades
            Enrollment selectedEnrollment = (Enrollment)this.enrollmentsListBox.SelectedValue;
            Assignment selectedAssignment = (Assignment)this.assignmentsListBox.SelectedValue;
            AssignmentGrade grade = this.dbContext.AssignmentGrades.Where(g =>
                g.Enrollment.Id == selectedEnrollment.Id &&
                g.Assignment.Id == selectedAssignment.Id).SingleOrDefault();
            this.pointsTextBox.Text = grade.Points.ToString();
            this.dateTextBox.Text = grade.DateCompleted.ToShortDateString();

            this.EnableEventHandlers();
        }

        private void departmentsDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            this.assignmentsListBox.DataSource = null;
            this.enrollmentsListBox.DataSource = null;
            this.sectionsDropDownList.DataSource = null;
            this.coursesDropDownList.DataSource = null;
            this.pointsTextBox.Text = null;
            this.dateTextBox.Text = null;
            
            Department selectedDept = (Department)this.departmentsDropDownList.SelectedItem;
            if (selectedDept.Courses.Count == 0)
                selectedDept.Courses = this.dbContext.Courses.Where(c =>
                    c.Department.Id == selectedDept.Id).ToList();

            this.coursesDropDownList.DisplayMember = "CourseTitle";
            this.coursesDropDownList.DataSource = selectedDept.Courses;
        }

        private void coursesDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            this.assignmentsListBox.DataSource = null;
            this.enrollmentsListBox.DataSource = null;
            this.sectionsDropDownList.DataSource = null;
            this.pointsTextBox.Text = null;
            this.dateTextBox.Text = null;

            Course selectedCourse = (Course)this.coursesDropDownList.SelectedItem;
            Term selectedTerm = (Term)this.termsDropDownList.SelectedItem;

            if (selectedCourse != null && selectedTerm != null)
            {
                selectedCourse.Sections = this.dbContext.Sections.Where(s =>
                    s.Course.Id == selectedCourse.Id &&
                    s.Term.Id == selectedTerm.Id).ToList();

                this.sectionsDropDownList.DisplayMember = "Id";
                this.sectionsDropDownList.DataSource = selectedCourse.Sections;
            }
        }

        private void termsDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            this.assignmentsListBox.DataSource = null;
            this.enrollmentsListBox.DataSource = null;
            this.sectionsDropDownList.DataSource = null;
            this.pointsTextBox.Text = null;
            this.dateTextBox.Text = null;

            Course selectedCourse = (Course)this.coursesDropDownList.SelectedItem;
            Term selectedTerm = (Term)this.termsDropDownList.SelectedItem;

            if (selectedCourse != null && selectedTerm != null)
            {
                selectedCourse.Sections = this.dbContext.Sections.Where(s =>
                    s.Course.Id == selectedCourse.Id &&
                    s.Term.Id == selectedTerm.Id).ToList();

                this.sectionsDropDownList.DisplayMember = "Id";
                this.sectionsDropDownList.DataSource = selectedCourse.Sections;
            }
        }

        private void sectionsDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            this.enrollmentsListBox.DataSource = null;
            this.assignmentsListBox.DataSource = null;

            Section selectedSection = (Section)this.sectionsDropDownList.SelectedItem;

            if (selectedSection != null)
            {
                selectedSection.Enrollments = this.dbContext.Enrollments.Include("Student").Where(enr =>
                    enr.Section.Id == selectedSection.Id).ToList();

                selectedSection.Assignments = this.dbContext.Assignments.Where(a =>
                    a.Section.Id == selectedSection.Id).ToList();

                enrollmentsListBox.DisplayMember = "DisplayString";
                this.enrollmentsListBox.DataSource = selectedSection.Enrollments;
                assignmentsListBox.DisplayMember = "DisplayString";
                this.assignmentsListBox.DataSource = selectedSection.Assignments;
            }
        }

        private void enrollmentsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.pointsTextBox.Text = "";
            this.dateTextBox.Text = "";

            Enrollment selectedEnrollment = (Enrollment)this.enrollmentsListBox.SelectedValue;
            Assignment selectedAssignment = (Assignment)this.assignmentsListBox.SelectedValue;

            if (selectedEnrollment != null && selectedAssignment != null)
            {
                AssignmentGrade grade = this.dbContext.AssignmentGrades.Where(g =>
                g.Enrollment.Id == selectedEnrollment.Id &&
                g.Assignment.Id == selectedAssignment.Id).SingleOrDefault();

                if (grade != null)
                {
                    this.pointsTextBox.Text = grade.Points.ToString();
                    this.dateTextBox.Text = grade.DateCompleted.ToShortDateString();
                }
            }
        }

        private void assignmentsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.pointsTextBox.Text = "";
            this.dateTextBox.Text = "";

            Enrollment selectedEnrollment = (Enrollment)this.enrollmentsListBox.SelectedValue;
            Assignment selectedAssignment = (Assignment)this.assignmentsListBox.SelectedValue;

            if (selectedEnrollment != null && selectedAssignment != null)
            {
                AssignmentGrade grade = this.dbContext.AssignmentGrades.Where(g =>
                g.Enrollment.Id == selectedEnrollment.Id &&
                g.Assignment.Id == selectedAssignment.Id).SingleOrDefault();

                if (grade != null)
                {
                    this.pointsTextBox.Text = grade.Points.ToString();
                    this.dateTextBox.Text = grade.DateCompleted.ToShortDateString();
                }
            }
        }

        private void saveGradeButton_Click(object sender, EventArgs e)
        {
            Enrollment selectedEnrollment = (Enrollment)this.enrollmentsListBox.SelectedValue;
            Assignment selectedAssignment = (Assignment)this.assignmentsListBox.SelectedValue;

            if (selectedEnrollment != null && selectedAssignment != null)
            {
                AssignmentGrade grade = selectedEnrollment.FindAssignmentGrade(selectedAssignment.Assign);
                if (grade == null)
                {
                    short points = 0;
                    Int16.TryParse(this.pointsTextBox.Text, out points);
                    grade = new AssignmentGrade(points, DateTime.Now,
                        selectedEnrollment, selectedAssignment);
                }
                else
                {
                    short points = 0;
                    Int16.TryParse(this.pointsTextBox.Text, out points);
                    grade.Points = points;
                    grade.DateCompleted = DateTime.Now;
                }
                this.dbContext.SaveChanges();
            }
        }

    }
}
