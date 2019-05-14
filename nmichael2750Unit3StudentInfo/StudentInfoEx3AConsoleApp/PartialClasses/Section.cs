using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoEx3AConsoleApp
{
    public partial class Section
    {
        public Section(int id, short capacity, Course course, Term term)
        {
            this.Assignments = new HashSet<Assignment>();
            this.Enrollments = new HashSet<Enrollment>();
            this.Id = id;
            this.Capacity = capacity;
            this.Course = course;
            course.Sections.Add(this);
            this.Term = term;
            term.Sections.Add(this);
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
                totalPoints = totalPoints + a.MaxPoints;
            }
            return totalPoints;
        }
    }

}
