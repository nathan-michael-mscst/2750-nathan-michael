using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoEx3AConsoleApp
{
    public partial class Enrollment
    {
        public Enrollment(int id, GradeTypesEnum gradeType, GradesEnum grade, Student student, Section section)
        {
            this.AssignmentGrades = new HashSet<AssignmentGrade>();
            this.Id = id;
            this.GradeType = gradeType;
            this.Grade = grade;
            this.Student = student;
            student.Enrollments.Add(this);
            this.Section = section;
            section.Enrollments.Add(this);
        }

        public AssignmentGrade FindAssignmentGrade(string assign)
        {
            AssignmentGrade foundAssignmentGrade = null;
            foreach (AssignmentGrade ag in this.AssignmentGrades)
            {
                if (ag.Assignment.Assign == assign)
                {
                    foundAssignmentGrade = ag;
                    break;
                }
            }
            return foundAssignmentGrade;
        }

        public int CalcTotalPoints()
        {
            int totalPoints = 0;
            foreach (AssignmentGrade ag in this.AssignmentGrades)
            {
                totalPoints = totalPoints + ag.Points;
            }
            return totalPoints;
        }

        public GradesEnum CalcGrade()
        {
            GradesEnum grade = GradesEnum.F;
            int totalPoints = this.CalcTotalPoints();
            int maxPoints = this.Section.CalcTotalPoints();
            double percent = (totalPoints * 100) / maxPoints ;

            if (percent >= 90)
                grade = GradesEnum.A;
            else if (percent >= 80)
                grade = GradesEnum.B;
            else if (percent >= 70)
                grade = GradesEnum.C;
            else if (percent >= 60)
                grade = GradesEnum.D;

            return grade;
        }

    }
}
