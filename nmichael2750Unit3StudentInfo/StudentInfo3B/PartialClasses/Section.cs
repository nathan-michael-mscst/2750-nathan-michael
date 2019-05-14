using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo3B
{
    public partial class Section
    {
        public Section(short capacity, Course course, Term term)
        {
            this.Enrollments = new List<Enrollment>();
            this.Assignments = new List<Assignment>();
            //this.Id = id;
            this.Capacity = capacity;
            this.Course = course;
            this.Course.Sections.Add(this);
            this.Term = term;
            this.Term.Sections.Add(this);
        }

        public Enrollment FindEnrollment(int personId)
        {
            Enrollment foundEnrollment = null;
            foreach (Enrollment e in this.Enrollments)
            {
                if (e.Student.Id == personId)
                {
                    foundEnrollment = e;
                    break;
                }
            }
            return foundEnrollment;
        }

        public Assignment FindAssignment(string assign)
        {
            Assignment foundAssignment = null;
            foreach (Assignment a in this.Assignments)
            {
                if (a.Assign == assign)
                {
                    foundAssignment = a;
                    break;
                }
            }
            return foundAssignment;
        }

        public int CalcTotalPoints()
        {
            int totalPoints = 0;
            foreach (Assignment a in Assignments)
            {
                totalPoints += a.MaxPoints;
            }
            return totalPoints;
        }

        public string DisplayString
        {
            get { return this.Id.ToString() + " " + this.Term.TermEnum.ToString() + " " + this.Course.CourseNum; }
        }
    }
}
