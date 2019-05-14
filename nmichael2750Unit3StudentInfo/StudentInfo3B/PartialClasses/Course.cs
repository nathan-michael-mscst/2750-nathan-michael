using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo3B
{
    public partial class Course
    {
       public Course(string courseNum, string courseTitle, short credits, Department dept)
        {
            this.Sections = new List<Section>();
            //this.Id = id;
            this.CourseNum = courseNum;
            this.CourseTitle = courseTitle;
            this.Credits = credits;
            this.Department = dept;
            this.Department.Courses.Add(this);
        }

        public Section FindSection(int id)
        {
            //return this.Sections.Find(s => s.Id == id);
            Section foundSection = null;

            foreach (Section s in this.Sections)
            {
                if (s.Id == id)
                {
                    foundSection = s;
                    break;
                }
            }
            return foundSection;
        }

        public List<Section> FindSections(Term term)
        {
            List<Section> foundSections = new List<Section>();
            foreach (Section s in this.Sections)
            {
                if (s.Term == term)
                    foundSections.Add(s);
            }
            return foundSections;
        }
    }
}
