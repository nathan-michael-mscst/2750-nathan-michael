using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo3B
{
    public partial class AssignmentGrade
    {
        public AssignmentGrade() { }

        public AssignmentGrade(short points, DateTime dateCompleted, 
            Enrollment enrollment, Assignment assignment)
        {
            //this.Id = id;
            this.Points = points;
            this.DateCompleted = dateCompleted;
            this.Enrollment = enrollment;
            this.Enrollment.AssignmentGrades.Add(this);
            this.Assignment = assignment;
            this.Assignment.AssignmentGrades.Add(this);
        }
    }
}
