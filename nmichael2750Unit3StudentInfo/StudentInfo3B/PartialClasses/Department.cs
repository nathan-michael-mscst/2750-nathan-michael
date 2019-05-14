using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo3B
{
    public partial class Department
    {
        public Department(string dept, string deptName, School school)
        {
            this.Courses = new List<Course>();
            //this.Id = id;
            this.Dept = dept;
            this.DeptName = deptName;
            this.School = school;
            school.Departments.Add(this);
        }

        public Course FindCourse(int id)
        {
            //return this.Courses.Find(c => c.Id == id);
            Course foundCourse = null;

            foreach (Course c in this.Courses)
            {
                if (c.Id == id)
                {
                    foundCourse = c;
                    break;
                }
            }
            return foundCourse;
        }

        public Course FindCourse(string courseNum)
        {
            //return this.Courses.Find(c => c.CourseNum == courseNum);
            Course foundCourse = null;

            foreach (Course c in this.Courses)
            {
                if (c.CourseNum == courseNum)
                {
                    foundCourse = c;
                    break;
                }
            }
            return foundCourse;
        }

        public Course FindCourseByTitle(string courseTitle)
        {
            //return this.Courses.Find(c => c.CourseTitle.Contains(courseTitle));
            Course foundCourse = null;

            foreach (Course c in this.Courses)
            {
                if (c.CourseTitle.Contains(courseTitle))
                {
                    foundCourse = c;
                    break;
                }
            }
            return foundCourse;
        }
    }
}
