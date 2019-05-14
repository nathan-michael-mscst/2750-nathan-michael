using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoEx3AConsoleApp
{
    public partial class Term
    {
        public Term(int id, short year, TermsEnum term, School school)
        {
            this.Sections = new HashSet<Section>();
            this.Id = id;
            this.Year = year;
            this.TermEnum = term;
            this.School = school;
            this.School.Terms.Add(this);
        }

        public Section FindSection(int id)
        {
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

        public Section FindSection(Course course, Term term)
        {
            Section foundSection = null;
            foreach (Section s in this.Sections)
            {
                if (s.Course.Id == course.Id && s.Term.Id == term.Id)
                {
                    foundSection = s;
                    break;
                }
            }
            return foundSection;
        }
    }
}
