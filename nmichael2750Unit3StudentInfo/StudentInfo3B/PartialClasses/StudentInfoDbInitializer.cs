using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace StudentInfo3B
{
    public class StudentInfoDBInitializer : DropCreateDatabaseAlways<StudentInfoModelContainer>
    {
        protected override void Seed(StudentInfoModelContainer dbContext)
        {
            //School school = new School();
            dbContext.Schools.Add(new School { SchoolName = "MN Southeast" });
            dbContext.SaveChanges();
            School school = dbContext.Schools.First();

            // Departments
            new Department("ADMS", "Administrative Support", school);
            new Department("ACCT", "Accounting", school);
            new Department("COMC", "Computer Careers", school);
            dbContext.SaveChanges();

            // Courses
            Department comc = school.FindDepartment("COMC");
            new Course("1730", "Intro to Programming with .Net", 3, comc);
            new Course("2740", "Introduction to Java/C/C++ Programming", 3, comc);
            new Course("2750", "UML Modeling and Iterative Process", 2, comc);
            dbContext.SaveChanges();

            // Terms
            new Term(2019, TermsEnum.Spr, school);
            new Term(2019, TermsEnum.Fall, school);
            new Term(2020, TermsEnum.Spr, school);
            dbContext.SaveChanges();

            // Students
            new Student("Alexander", "Carson", "carson.alexander", "carson.alexander@email.com", "111-111-1111", "1111 11th St", "Red Wing", "MN", "55066", school);
            new Student("Alonso", "Meredith", "meredith.alonso", "meredith.alonso@email.com", "111-111-1112", "1112 12th St", "Red Wing", "MN", "55066", school);
            new Student("Anand", "Arturo", "arturo.anand", "arturo.anand@email.com", "111-111-1113", "1113 13th St", "Red Wing", "MN", "55066", school);
            new Student("Barzdukas", "Gytis", "gytis.barzdukas", "gytis.barzdukas@email.com", "111-111-1114", "1114 14th St", "Red Wing", "MN", "55066", school);
            new Student("Li", "Yan", "yan.li", "yan.li@email.com", "111-111-1115", "1115 15th St", "Red Wing", "MN", "55066", school);
            new Student("Justice", "Peggy", "peggy.justice", "peggy.justice@email.com", "111-111-1116", "1116 16th St", "Red Wing", "MN", "55066", school);
            new Student("Norman", "Laura", "laura.norman", "laura.norman@email.com", "111-111-1117", "1117 17th St", "Red Wing", "MN", "55066", school);
            new Student("Olivetto", "Nino", "nino.olivetto", "nino.olivetto@email.com", "111-111-1118", "1118 18th St", "Red Wing", "MN", "55066", school);
            new Student("Abercrombie", "Kim", "kim.abercrombie", "kim.abercrombie@email.com", "111-111-1119", "1119 19th St", "Red Wing", "MN", "55066", school);
            new Student("Fakhouri", "Fadi", "fadi.fakhouri", "fadi.fakhouri@email.com", "111-111-1121", "1121 21st St", "Winona", "MN", "55987", school);
            new Student("Harui", "Roger", "roger.harui", "roger.harui@email.com", "111-111-1122", "1122 22nd St", "Winona", "MN", "55987", school);
            new Student("Kapoor", "Candace", "candace.kapoor", "candace.kapoor@email.com", "111-111-1123", "1123 23rd St", "Winona", "MN", "55987", school);
            new Student("Zheng", "Roger", "roger.zheng", "roger.zheng@email.com", "111-111-1124", "1124 24th St", "Winona", "MN", "55987", school);
            dbContext.SaveChanges();

            // Sections
            Course comc2750 = comc.FindCourse("2750");
            Term term2019spr = school.FindTerm(2019, TermsEnum.Spr);
            new Section(30, comc2750, term2019spr);

            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750a = new Section(24, comc2750, term2020spr);
            Section section2750b = new Section(30, comc2750, term2020spr);
            dbContext.SaveChanges();

            // Enrollments
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(2), section2750a);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(4), section2750a);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(6), section2750a);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(8), section2750a);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10), section2750a);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(12), section2750a);

            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(1), section2750b);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(3), section2750b);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(5), section2750b);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(7), section2750b);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(9), section2750b);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(11), section2750b);
            new Enrollment(GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(13), section2750b);
            dbContext.SaveChanges();

            // Assignments
            new Assignment("1A", "Worksheet, identify student grade info classes",
                10, DateTime.Parse("1/23/2019"), AssignmentTypesEnum.E, section2750b);
            new Assignment("1B", "UML domain model, library books",
                10, DateTime.Parse("1/29/2019"), AssignmentTypesEnum.E, section2750b);
            new Assignment("1C", "UML Student Info domain model w/associations",
                10, DateTime.Parse("1/30/2019"), AssignmentTypesEnum.E, section2750b);
            new Assignment("1D", "Modify 1B (Library system): add attributes & operations",
                10, DateTime.Parse("2/1/2019"), AssignmentTypesEnum.E, section2750b);
            new Assignment("Q1", "Quiz 1",
                50, DateTime.Parse("2/2/2019"), AssignmentTypesEnum.Q, section2750b);
            dbContext.SaveChanges();

            // AssignmentGrades
            new AssignmentGrade(10, DateTime.Parse("1/20/2019"),
                section2750b.FindEnrollment(1), section2750b.FindAssignment("1A"));
            new AssignmentGrade(9, DateTime.Parse("1/21/2019"),
                section2750b.FindEnrollment(3), section2750b.FindAssignment("1A"));
            new AssignmentGrade(8, DateTime.Parse("1/22/2019"),
                section2750b.FindEnrollment(5), section2750b.FindAssignment("1A"));
            new AssignmentGrade(7, DateTime.Parse("1/23/2019"),
                section2750b.FindEnrollment(7), section2750b.FindAssignment("1A"));
            new AssignmentGrade(10, DateTime.Parse("1/20/2019"),
                section2750b.FindEnrollment(9), section2750b.FindAssignment("1A"));
            new AssignmentGrade(9, DateTime.Parse("1/21/2019"),
                section2750b.FindEnrollment(11), section2750b.FindAssignment("1A"));
            new AssignmentGrade(8, DateTime.Parse("1/22/2019"),
                section2750b.FindEnrollment(13), section2750b.FindAssignment("1A"));
            new AssignmentGrade(10, DateTime.Parse("1/23/2019"),
                section2750b.FindEnrollment(1), section2750b.FindAssignment("1B"));
            new AssignmentGrade(9, DateTime.Parse("1/24/2019"),
                section2750b.FindEnrollment(3), section2750b.FindAssignment("1B"));
            new AssignmentGrade(8, DateTime.Parse("1/25/2019"),
                section2750b.FindEnrollment(5), section2750b.FindAssignment("1B"));
            new AssignmentGrade(7, DateTime.Parse("1/26/2019"),
                section2750b.FindEnrollment(7), section2750b.FindAssignment("1B"));
            new AssignmentGrade(8, DateTime.Parse("1/24/2019"),
                section2750b.FindEnrollment(9), section2750b.FindAssignment("1B"));
            new AssignmentGrade(9, DateTime.Parse("1/25/2019"),
                section2750b.FindEnrollment(11), section2750b.FindAssignment("1B"));
            new AssignmentGrade(10, DateTime.Parse("1/23/2019"),
                section2750b.FindEnrollment(13), section2750b.FindAssignment("1B"));
            new AssignmentGrade(9, DateTime.Parse("1/28/2019"),
                section2750b.FindEnrollment(1), section2750b.FindAssignment("1C"));
            new AssignmentGrade(8, DateTime.Parse("1/29/2019"),
                section2750b.FindEnrollment(5), section2750b.FindAssignment("1C"));
            new AssignmentGrade(7, DateTime.Parse("1/30/2019"),
                section2750b.FindEnrollment(7), section2750b.FindAssignment("1C"));
            new AssignmentGrade(10, DateTime.Parse("1/26/2019"),
                section2750b.FindEnrollment(5), section2750b.FindAssignment("1D"));
            new AssignmentGrade(46, DateTime.Parse("1/26/2019"),
                section2750b.FindEnrollment(5), section2750b.FindAssignment("Q1"));
            dbContext.SaveChanges();

            base.Seed(dbContext);
        }
    }
}
