using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoEx3AConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new School();

            // Departments
            System.Console.WriteLine("---------- Departments ----------");
            new Department(1001, "ADMS", "Administrative Support", school);
            new Department(1002, "ACCT", "Accounting", school);
            new Department(1003, "COMC", "Computer Careers", school);


            foreach (Department d in school.Departments)
            {
                System.Console.WriteLine(d.Id.ToString() + "\t" + d.Dept + "\t" + d.DeptName);
            }

            Department comc = school.FindDepartment("COMC");

            // Terms
            System.Console.WriteLine("----------    Terms    ----------");
            new Term(101, 2019, TermsEnum.Spr, school);
            new Term(102, 2019, TermsEnum.Fall, school);
            new Term(103, 2020, TermsEnum.Spr, school);

            foreach (Term t in school.Terms)
            {
                System.Console.WriteLine(t.Id.ToString() + "\t"
                    + t.Year.ToString() + "\t" + t.TermEnum.ToString());
            }

            // Students
            System.Console.WriteLine("----------  Students  ----------");

            new Student(10000011, "Alexander", "Carson", "carson.alexander", "carson.alexander@email.com", "111-111-1111", "1111 11th St", "Red Wing", "MN", "55066", school);
            new Student(10000012, "Alonso", "Meredith", "meredith.alonso", "meredith.alonso@email.com", "111-111-1112", "1112 12th St", "Red Wing", "MN", "55066", school);
            new Student(10000013, "Anand", "Arturo", "arturo.anand", "arturo.anand@email.com", "111-111-1113", "1113 13th St", "Red Wing", "MN", "55066", school);
            new Student(10000014, "Barzdukas", "Gytis", "gytis.barzdukas", "gytis.barzdukas@email.com", "111-111-1114", "1114 14th St", "Red Wing", "MN", "55066", school);
            new Student(10000015, "Li", "Yan", "yan.li", "yan.li@email.com", "111-111-1115", "1115 15th St", "Red Wing", "MN", "55066", school);
            new Student(10000016, "Justice", "Peggy", "peggy.justice", "peggy.justice@email.com", "111-111-1116", "1116 16th St", "Red Wing", "MN", "55066", school);
            new Student(10000017, "Norman", "Laura", "laura.norman", "laura.norman@email.com", "111-111-1117", "1117 17th St", "Red Wing", "MN", "55066", school);
            new Student(10000018, "Olivetto", "Nino", "nino.olivetto", "nino.olivetto@email.com", "111-111-1118", "1118 18th St", "Red Wing", "MN", "55066", school);
            new Student(10000019, "Abercrombie", "Kim", "kim.abercrombie", "kim.abercrombie@email.com", "111-111-1119", "1119 19th St", "Red Wing", "MN", "55066", school);
            new Student(10000021, "Fakhouri", "Fadi", "fadi.fakhouri", "fadi.fakhouri@email.com", "111-111-1121", "1121 21st St", "Winona", "MN", "55987", school);
            new Student(10000022, "Harui", "Roger", "roger.harui", "roger.harui@email.com", "111-111-1122", "1122 22nd St", "Winona", "MN", "55987", school);
            new Student(10000023, "Kapoor", "Candace", "candace.kapoor", "candace.kapoor@email.com", "111-111-1123", "1123 23rd St", "Winona", "MN", "55987", school);
            new Student(10000024, "Zheng", "Roger", "roger.zheng", "roger.zheng@email.com", "111-111-1124", "1124 24th St", "Winona", "MN", "55987", school);

            foreach (Student s in school.Students)
            {
                System.Console.WriteLine(s.Id.ToString() + "  " + s.FirstName + ' ' + s.LastName);
            }

            // Courses
            System.Console.WriteLine("----------   Courses   ----------");
            comc.Courses.Add(new Course(100001, "1730", "Intro to Programming with .Net", 3, comc));
            comc.Courses.Add(new Course(100002, "2740", "Introduction to Java/C/C++ Programming", 3, comc));
            comc.Courses.Add(new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc));

            foreach (Course c in comc.Courses)
            {
                System.Console.WriteLine(c.Id.ToString() + "\t" + c.Department.Dept + c.CourseNum + "  " + c.Credits.ToString() + "cr  " + c.CourseTitle);
            }

            Course comc2750 = null;
            comc2750 = comc.FindCourse(100003);
            System.Console.WriteLine("Found CourseId: " + "\t"
                + comc2750.Id.ToString() + "  " + comc2750.Department.Dept
                + comc2750.CourseNum + "  " + comc2750.Credits.ToString()
                + "cr  " + comc2750.CourseTitle);
            comc2750 = comc.FindCourse("2750");
            System.Console.WriteLine("Found CourseNum: " + "\t"
                + comc2750.Id.ToString() + "  " + comc2750.Department.Dept
                + comc2750.CourseNum + "  " + comc2750.Credits.ToString()
                + "cr  " + comc2750.CourseTitle);
            comc2750 = comc.FindCourseByTitle("UML");
            System.Console.WriteLine("Found CourseTitle: "
                + "\t" + comc2750.Id.ToString() + "  " + comc2750.Department.Dept
                + comc2750.CourseNum + "  " + comc2750.Credits.ToString()
                + "cr  " + comc2750.CourseTitle);

            // Sections
            System.Console.WriteLine("----------   Sections   ----------");
            Section section2750 = null;
            Term term2019spr = school.FindTerm(2019, TermsEnum.Spr);
            section2750 = new Section(100001, 30, comc2750, term2019spr);

            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            section2750 = new Section(100002, 24, comc2750, term2020spr);
            section2750 = new Section(100003, 30, comc2750, term2020spr);

            System.Console.WriteLine(comc2750.Department.Dept + comc2750.CourseNum + ":");
            foreach (Section s in comc2750.Sections)
            {
                System.Console.WriteLine("\t" + s.Term.Year.ToString() + s.Term.TermEnum.ToString() + "\t"
                    + s.Id.ToString() + "\tCap: " + s.Capacity.ToString());
            }
            System.Console.WriteLine(term2020spr.Year.ToString() + term2020spr.TermEnum.ToString() + ":");
            foreach (Section s in term2020spr.Sections)
            {
                System.Console.WriteLine("\t" + s.Course.Department.Dept + s.Course.CourseNum + "  "
                    + s.Id.ToString() + "  Cap: " + s.Capacity.ToString());
            }

            // Enrollments
            System.Console.WriteLine("----------  Enrollments  ----------");
            new Enrollment(10000001, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000011), section2750);
            new Enrollment(10000002, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000013), section2750);
            new Enrollment(10000003, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000015), section2750);
            new Enrollment(10000004, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000017), section2750);
            new Enrollment(10000005, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000019), section2750);
            new Enrollment(10000006, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000021), section2750);
            new Enrollment(10000007, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000022), section2750);
            System.Console.WriteLine(section2750.Term.Year.ToString() + section2750.Term.TermEnum.ToString() + "\t"
                    + section2750.Id.ToString() + "\t" + section2750.Course.Department.Dept + section2750.Course.CourseNum);
            foreach (Enrollment e in section2750.Enrollments)
            {
                System.Console.WriteLine("\tGrade: " + e.Grade.ToString() + "  " + e.Student.Id
                    + "  " + e.Student.LastName + ", " + e.Student.FirstName);
            }

            // Assignments
            System.Console.WriteLine("----------  Assignments  ----------");
            new Assignment(10000001, "1A", "Worksheet, identify student grade info classes",
                10, DateTime.Parse("1/23/2019"), AssignmentTypesEnum.E, section2750);
            new Assignment(10000002, "1B", "UML domain model, library books",
                10, DateTime.Parse("1/29/2019"), AssignmentTypesEnum.E, section2750);
            new Assignment(10000003, "1C", "UML Student Info domain model w/associations",
                10, DateTime.Parse("1/30/2019"), AssignmentTypesEnum.E, section2750);
            new Assignment(10000004, "1D", "Modify 1B (Library system): add attributes & operations",
                10, DateTime.Parse("2/1/2019"), AssignmentTypesEnum.E, section2750);
            new Assignment(10000005, "Q1", "Quiz 1",
                50, DateTime.Parse("2/2/2019"), AssignmentTypesEnum.Q, section2750);

            System.Console.WriteLine(section2750.Term.Year.ToString() + section2750.Term.TermEnum.ToString() + "\t"
                + section2750.Id.ToString() + "\t" + section2750.Course.Department.Dept + section2750.Course.CourseNum);
            foreach (Assignment a in section2750.Assignments)
            {
                System.Console.WriteLine("\t" + a.Assign + "  Pts: " + a.MaxPoints + "  " + a.Description);
            }

            // AssignmentGrades
            System.Console.WriteLine("-------  Assignment Grades  -------");
            new AssignmentGrade(10000001, 10, DateTime.Parse("1/20/2019"),
                section2750.FindEnrollment(10000011), section2750.FindAssignment("1A"));
            new AssignmentGrade(10000002, 9, DateTime.Parse("1/21/2019"),
                section2750.FindEnrollment(10000013), section2750.FindAssignment("1A"));
            new AssignmentGrade(10000003, 8, DateTime.Parse("1/22/2019"),
                section2750.FindEnrollment(10000015), section2750.FindAssignment("1A"));
            new AssignmentGrade(10000004, 7, DateTime.Parse("1/23/2019"),
                section2750.FindEnrollment(10000017), section2750.FindAssignment("1A"));
            new AssignmentGrade(10000005, 10, DateTime.Parse("1/20/2019"),
                section2750.FindEnrollment(10000019), section2750.FindAssignment("1A"));
            new AssignmentGrade(10000006, 9, DateTime.Parse("1/21/2019"),
                section2750.FindEnrollment(10000021), section2750.FindAssignment("1A"));
            new AssignmentGrade(10000007, 8, DateTime.Parse("1/22/2019"),
                section2750.FindEnrollment(10000022), section2750.FindAssignment("1A"));
            new AssignmentGrade(10000008, 10, DateTime.Parse("1/23/2019"),
                section2750.FindEnrollment(10000011), section2750.FindAssignment("1B"));
            new AssignmentGrade(10000009, 9, DateTime.Parse("1/24/2019"),
                section2750.FindEnrollment(10000013), section2750.FindAssignment("1B"));
            new AssignmentGrade(10000010, 8, DateTime.Parse("1/25/2019"),
                section2750.FindEnrollment(10000015), section2750.FindAssignment("1B"));
            new AssignmentGrade(10000011, 7, DateTime.Parse("1/26/2019"),
                section2750.FindEnrollment(10000017), section2750.FindAssignment("1B"));
            new AssignmentGrade(10000012, 8, DateTime.Parse("1/24/2019"),
                section2750.FindEnrollment(10000019), section2750.FindAssignment("1B"));
            new AssignmentGrade(10000013, 9, DateTime.Parse("1/25/2019"),
                section2750.FindEnrollment(10000021), section2750.FindAssignment("1B"));
            new AssignmentGrade(10000014, 10, DateTime.Parse("1/23/2019"),
                section2750.FindEnrollment(10000022), section2750.FindAssignment("1B"));
            new AssignmentGrade(10000015, 9, DateTime.Parse("1/28/2019"),
                section2750.FindEnrollment(10000011), section2750.FindAssignment("1C"));
            new AssignmentGrade(10000016, 8, DateTime.Parse("1/29/2019"),
                section2750.FindEnrollment(10000015), section2750.FindAssignment("1C"));
            new AssignmentGrade(10000017, 7, DateTime.Parse("1/30/2019"),
                section2750.FindEnrollment(10000017), section2750.FindAssignment("1C"));
            new AssignmentGrade(10000018, 10, DateTime.Parse("1/26/2019"),
                section2750.FindEnrollment(10000015), section2750.FindAssignment("1D"));
            new AssignmentGrade(10000020, 46, DateTime.Parse("1/26/2019"),
                section2750.FindEnrollment(10000015), section2750.FindAssignment("Q1"));

            foreach (Assignment a in section2750.Assignments)
            {
                System.Console.WriteLine(a.Assign + "  Pts: " + a.MaxPoints + "  " + a.Description);
                foreach (AssignmentGrade g in a.AssignmentGrades)
                {
                    System.Console.WriteLine("\t" + g.Points.ToString("n0").PadLeft(2) + "  " + g.Enrollment.Student.LastName + ", " + g.Enrollment.Student.FirstName);
                }
            }

            System.Console.WriteLine(section2750.Term.Year.ToString() + section2750.Term.TermEnum.ToString() + "\t"
                + section2750.Id.ToString() + "\t" + section2750.Course.Department.Dept + section2750.Course.CourseNum);
            foreach (Enrollment e in section2750.Enrollments)
            {
                System.Console.WriteLine("\tTotal: " + e.CalcTotalPoints().ToString("n0").PadLeft(2) + "  " + e.Student.LastName + ", " + e.Student.FirstName);
            }
        }
    }
}
