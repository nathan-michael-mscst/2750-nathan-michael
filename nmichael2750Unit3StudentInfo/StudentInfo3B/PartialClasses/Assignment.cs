using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo3B
{
    public partial class Assignment { 
        public Assignment(string assign, string description, 
            short maxPoints, DateTime dueDate, AssignmentTypesEnum type, Section section)
        {
            this.AssignmentGrades = new List<AssignmentGrade>();
            //this.Id = id;
            this.Assign = assign;
            this.Description = description;
            this.MaxPoints = maxPoints;
            this.DueDate = dueDate;
            this.Type = type;
            this.Section = section;
            this.Section.Assignments.Add(this);
        }

        public AssignmentGrade FindAssignmentGrade(int studentId)
        {
            AssignmentGrade foundGrade = null;
            foreach (AssignmentGrade g in this.AssignmentGrades)
            {
                if (g.Enrollment.Student.Id == studentId)
                {
                    foundGrade = g;
                    break;
                }
            }
            return foundGrade;
        }

        public string DisplayString
        {
            get { return this.Assign + " Max: " + this.MaxPoints.ToString() + ", " + this.DueDate.ToShortDateString(); }
        }
    }
}
