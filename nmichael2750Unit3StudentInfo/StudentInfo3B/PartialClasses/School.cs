using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo3B
{
    public partial class School
    {
        public Department FindDepartment(string dept)
        {
            Department foundDepartment = null;
            foreach (Department d in this.Departments)
            {
                if (d.Dept == dept)
                {
                    foundDepartment = d;
                    break;
                }
            }
            return foundDepartment;
        }

        public Term FindTerm(short year, TermsEnum term)
        {
            Term foundTerm = null;
            foreach (Term t in this.Terms)
            {
                if (t.Year == year && t.TermEnum == term)
                {
                    foundTerm = t;
                    break;
                }
            }
            return foundTerm;
        }

        public Student FindStudent(int id)
        {
            Student foundStudent = null;
            foreach (Student s in this.Students)
            {
                if (s.Id == id)
                {
                    foundStudent = (Student)s;
                    break;
                }
            }
            return foundStudent;
        }
    }
}
