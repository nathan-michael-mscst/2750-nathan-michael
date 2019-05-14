using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo3B
{
    public partial class Enrollment
    {
        public Enrollment(GradeTypesEnum gradeType, GradesEnum grade, Student student, Section section)
        {
            this.AssignmentGrades = new List<AssignmentGrade>();
            //this.Id = id;
            this.GradeType = gradeType;
            this.Grade = grade;
            this.Student = student;
            this.Student.Enrollments.Add(this);
            this.Section = section;
            this.Section.Enrollments.Add(this);
        }

        public AssignmentGrade FindAssignmentGrade(string assign)
        {
            AssignmentGrade foundGrade = null;
            foreach (AssignmentGrade g in this.AssignmentGrades)
            {
                if (g.Assignment.Assign == assign)
                {
                    foundGrade = g;
                    break;
                }
            }
            return foundGrade;
        }

        public int CalcTotalPoints()
        {
            int totalPoints = 0;
            foreach (AssignmentGrade g in this.AssignmentGrades)
            {
                totalPoints += g.Points;
            }
            return totalPoints;
        }

        public GradesEnum CalcGrade()
        {
            GradesEnum grade = GradesEnum.Z;
            int maxPoints = this.Section.CalcTotalPoints();
            if (maxPoints > 0)
            {
                int totalPoints = this.CalcTotalPoints();
                double pct = totalPoints * 100 / maxPoints;

                if (pct >= 90.0)
                    grade = GradesEnum.A;
                else if (pct >= 80.0)
                    grade = GradesEnum.B;
                else if (pct >= 70.0)
                    grade = GradesEnum.C;
                else if (pct >= 60.0)
                    grade = GradesEnum.D;
                else
                    grade = GradesEnum.F;
            }
            return grade;
        }

        public string DisplayString
        {
            get { return this.Student.Id.ToString() + " " 
                    + this.CalcTotalPoints().ToString() + "/"
                    + this.Section.CalcTotalPoints() + " = "
                    + this.CalcGrade() + ", "
                    + this.Student.LastName + ", " 
                    + this.Student.FirstName; }
        }
    }
}
