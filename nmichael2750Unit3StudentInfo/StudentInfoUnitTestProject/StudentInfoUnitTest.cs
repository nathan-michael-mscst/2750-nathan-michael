using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StudentInfoEx3AConsoleApp;

namespace StudentInfoUnitTestProject
{
    [TestClass]
    public class StudentInfoUnitTest
    {
        private School school = new School();

        [TestInitialize]
        public void TestInitialize()
        {
            // Departments
            new Department(1001, "ADMS", "Administrative Support", school);
            new Department(1002, "ACCT", "Accounting", school);
            new Department(1003, "COMC", "Computer Careers", school);
            // Terms
            new Term(101, 2019, TermsEnum.Spr, school);
            new Term(102, 2019, TermsEnum.Fall, school);
            new Term(103, 2020, TermsEnum.Spr, school);
            // Students
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
        }

        [TestMethod]
        public void SchoolFindDepartment()
        {
            Department comc = this.school.FindDepartment("COMC");
            Assert.AreEqual(1003, comc.Id);
        }

        [TestMethod]
        public void SchoolFindStudent()
        {
            Student kapoor = this.school.FindStudent(10000023);
            Assert.AreEqual("Kapoor", kapoor.LastName);
        }

        [TestMethod]
        public void SchoolFindTerm()
        {
            Term fall2019 = this.school.FindTerm(2019, TermsEnum.Fall);
            Assert.AreEqual(102, fall2019.Id);
        }

        [TestMethod]
        public void DepartmentFindCourse()
        {
            Department comc = this.school.FindDepartment("COMC");
            new Course(100001, "1730", "Intro to Programming with .Net", 3, comc);
            new Course(100002, "2740", "Introduction to Java/C/C++ Programming", 3, comc);
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Course foundComc2750 = comc.FindCourse(100003);
            Assert.AreSame(comc2750, foundComc2750);
        }

        [TestMethod]
        public void CourseFindSection()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_202spr = new Section(100002, 24, comc2750, term2020spr);
            Section foundSection = comc2750.FindSection(100002);
            Assert.AreSame(section2750_202spr, foundSection);
        }

        [TestMethod]
        public void TermFindSection()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_202spr = new Section(100002, 24, comc2750, term2020spr);
            Section foundSection = term2020spr.FindSection(100002);
            Assert.AreSame(section2750_202spr, foundSection);
        }

        [TestMethod]
        public void SectionFindEnrollment()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_2020spr = new Section(100002, 24, comc2750, term2020spr);

            Student student = null;
            // Add enrollments
            student = school.FindStudent(10000011);
            new Enrollment(10000001, GradeTypesEnum.AF, GradesEnum.Z, student, section2750_2020spr);
            student = school.FindStudent(10000013);
            new Enrollment(10000002, GradeTypesEnum.AF, GradesEnum.Z, student, section2750_2020spr);
            student = school.FindStudent(10000015);
            new Enrollment(10000003, GradeTypesEnum.AF, GradesEnum.Z, student, section2750_2020spr);

            // Find Enrollment
            Enrollment e13 = section2750_2020spr.FindEnrollment(10000013);
            Assert.AreEqual(10000013, e13.Student.Id);
        }

        [TestMethod]
        public void StudentFindEnrollment()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            //comc.Courses.Add(comc2750);
            Term t = null;
            t = school.FindTerm(2019, TermsEnum.Spr);
            Section section2750_2019spr = new Section(100001, 30, comc2750, t);
            t = school.FindTerm(2019, TermsEnum.Fall);
            Section section2750_2019fall = new Section(100002, 24, comc2750, t);
            t = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_2020spr = new Section(100003, 24, comc2750, t);

            // Add enrollments
            Student student = student = school.FindStudent(10000013);
            new Enrollment(10000001, GradeTypesEnum.AF, GradesEnum.Z, student, section2750_2019spr);
            new Enrollment(10000002, GradeTypesEnum.AF, GradesEnum.Z, student, section2750_2019fall);
            new Enrollment(10000003, GradeTypesEnum.AF, GradesEnum.Z, student, section2750_2020spr);

            // Find Enrollment
            Enrollment e = student.FindEnrollment(100002);
            Assert.AreEqual(10000002, e.Id);
        }

        [TestMethod]
        public void SectionFindAssignment()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_2020spr = new Section(100002, 24, comc2750, term2020spr);

            // Add Assignments
            new Assignment(10000001, "1A", "Worksheet, identify student grade info classes",
                10, DateTime.Parse("1/23/2019"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000002, "1B", "UML domain model, library books",
                10, DateTime.Parse("1/29/2019"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000003, "1C", "UML Student Info domain model w/associations",
                10, DateTime.Parse("1/30/2019"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000004, "1D", "Modify 1B (Library system): add attributes & operations",
                10, DateTime.Parse("2/1/2019"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000005, "Q1", "Quiz 1",
                50, DateTime.Parse("2/2/2019"), AssignmentTypesEnum.Q, section2750_2020spr);

            // Find Assignment
            Assignment ex1C = section2750_2020spr.FindAssignment("1C");
            Assert.AreEqual(10000003, ex1C.Id);
        }

        [TestMethod]
        public void EnrollmentFindAssignmentGrade()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_2020spr = new Section(100002, 24, comc2750, term2020spr);

            // Add Assignments
            new Assignment(10000001, "1A", "Worksheet, identify student grade info classes",
                10, DateTime.Parse("1/23/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000002, "1B", "UML domain model, library books",
                10, DateTime.Parse("1/29/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000003, "1C", "UML Student Info domain model w/associations",
                10, DateTime.Parse("1/30/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000004, "1D", "Modify 1B (Library system): add attributes & operations",
                10, DateTime.Parse("2/1/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000005, "Q1", "Quiz 1",
                50, DateTime.Parse("2/2/2020"), AssignmentTypesEnum.Q, section2750_2020spr);

            // Add enrollments
            new Enrollment(10000001, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000011), section2750_2020spr);
            new Enrollment(10000002, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000013), section2750_2020spr);
            new Enrollment(10000003, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000015), section2750_2020spr);
            new Enrollment(10000004, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000017), section2750_2020spr);
            new Enrollment(10000005, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000019), section2750_2020spr);
            new Enrollment(10000006, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000021), section2750_2020spr);
            new Enrollment(10000007, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000023), section2750_2020spr);

            // Add AssignmentGrades
            new AssignmentGrade(10000001, 10, DateTime.Parse("1/20/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000002, 9, DateTime.Parse("1/21/2019"),
                section2750_2020spr.FindEnrollment(10000013), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000003, 8, DateTime.Parse("1/22/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000004, 7, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000017), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000005, 10, DateTime.Parse("1/20/2019"),
                section2750_2020spr.FindEnrollment(10000019), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000006, 9, DateTime.Parse("1/21/2019"),
                section2750_2020spr.FindEnrollment(10000021), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000007, 8, DateTime.Parse("1/22/2019"),
                section2750_2020spr.FindEnrollment(10000023), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000008, 10, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000009, 9, DateTime.Parse("1/24/2019"),
                section2750_2020spr.FindEnrollment(10000013), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000010, 8, DateTime.Parse("1/25/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000011, 7, DateTime.Parse("1/26/2019"),
                section2750_2020spr.FindEnrollment(10000017), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000012, 8, DateTime.Parse("1/24/2019"),
                section2750_2020spr.FindEnrollment(10000019), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000013, 9, DateTime.Parse("1/25/2019"),
                section2750_2020spr.FindEnrollment(10000021), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000014, 10, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000023), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000015, 9, DateTime.Parse("1/28/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1C"));
            new AssignmentGrade(10000016, 8, DateTime.Parse("1/29/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1C"));
            new AssignmentGrade(10000017, 7, DateTime.Parse("1/30/2019"),
                section2750_2020spr.FindEnrollment(10000017), section2750_2020spr.FindAssignment("1C"));

            Enrollment enr = section2750_2020spr.FindEnrollment(10000015);
            AssignmentGrade g = enr.FindAssignmentGrade("1B");
            Assert.AreEqual(10000010, g.Id);
        }

        [TestMethod]
        public void AssignmentFindAssignmentGrade()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_2020spr = new Section(100002, 24, comc2750, term2020spr);

            // Add Assignments
            new Assignment(10000001, "1A", "Worksheet, identify student grade info classes",
                10, DateTime.Parse("1/23/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000002, "1B", "UML domain model, library books",
                10, DateTime.Parse("1/29/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000003, "1C", "UML Student Info domain model w/associations",
                10, DateTime.Parse("1/30/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000004, "1D", "Modify 1B (Library system): add attributes & operations",
                10, DateTime.Parse("2/1/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000005, "Q1", "Quiz 1",
                50, DateTime.Parse("2/2/2020"), AssignmentTypesEnum.Q, section2750_2020spr);

            // Add enrollments
            new Enrollment(10000001, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000011), section2750_2020spr);
            new Enrollment(10000002, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000013), section2750_2020spr);
            new Enrollment(10000003, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000015), section2750_2020spr);
            new Enrollment(10000004, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000017), section2750_2020spr);
            new Enrollment(10000005, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000019), section2750_2020spr);
            new Enrollment(10000006, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000021), section2750_2020spr);
            new Enrollment(10000007, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000023), section2750_2020spr);

            // Add AssignmentGrades
            new AssignmentGrade(10000001, 10, DateTime.Parse("1/20/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000002, 9, DateTime.Parse("1/21/2019"),
                section2750_2020spr.FindEnrollment(10000013), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000003, 8, DateTime.Parse("1/22/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000004, 7, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000017), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000005, 10, DateTime.Parse("1/20/2019"),
                section2750_2020spr.FindEnrollment(10000019), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000006, 9, DateTime.Parse("1/21/2019"),
                section2750_2020spr.FindEnrollment(10000021), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000007, 8, DateTime.Parse("1/22/2019"),
                section2750_2020spr.FindEnrollment(10000023), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000008, 10, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000009, 9, DateTime.Parse("1/24/2019"),
                section2750_2020spr.FindEnrollment(10000013), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000010, 8, DateTime.Parse("1/25/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000011, 7, DateTime.Parse("1/26/2019"),
                section2750_2020spr.FindEnrollment(10000017), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000012, 8, DateTime.Parse("1/24/2019"),
                section2750_2020spr.FindEnrollment(10000019), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000013, 9, DateTime.Parse("1/25/2019"),
                section2750_2020spr.FindEnrollment(10000021), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000014, 10, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000023), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000015, 9, DateTime.Parse("1/28/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1C"));
            new AssignmentGrade(10000016, 8, DateTime.Parse("1/29/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1C"));
            new AssignmentGrade(10000017, 7, DateTime.Parse("1/30/2019"),
                section2750_2020spr.FindEnrollment(10000017), section2750_2020spr.FindAssignment("1C"));

            Assignment a = section2750_2020spr.FindAssignment("1B");
            AssignmentGrade g = a.FindAssignmentGrade(10000013);
            Assert.AreEqual(10000009, g.Id);
        }

        [TestMethod]
        public void EnrollmentCalcTotalPoints()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_2020spr = new Section(100002, 24, comc2750, term2020spr);

            // Add Assignments
            new Assignment(10000001, "1A", "Worksheet, identify student grade info classes",
                10, DateTime.Parse("1/23/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000002, "1B", "UML domain model, library books",
                10, DateTime.Parse("1/29/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000003, "1C", "UML Student Info domain model w/associations",
                10, DateTime.Parse("1/30/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000004, "1D", "Modify 1B (Library system): add attributes & operations",
                10, DateTime.Parse("2/1/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000005, "Q1", "Quiz 1",
                50, DateTime.Parse("2/2/2020"), AssignmentTypesEnum.Q, section2750_2020spr);

            // Add enrollments
            new Enrollment(10000001, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000011), section2750_2020spr);
            new Enrollment(10000002, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000013), section2750_2020spr);
            new Enrollment(10000003, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000015), section2750_2020spr);
            new Enrollment(10000004, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000017), section2750_2020spr);
            new Enrollment(10000005, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000019), section2750_2020spr);
            new Enrollment(10000006, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000021), section2750_2020spr);
            new Enrollment(10000007, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000023), section2750_2020spr);

            // Add AssignmentGrades
            new AssignmentGrade(10000001, 10, DateTime.Parse("1/20/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000002, 9, DateTime.Parse("1/21/2019"),
                section2750_2020spr.FindEnrollment(10000013), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000003, 8, DateTime.Parse("1/22/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000004, 7, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000017), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000005, 10, DateTime.Parse("1/20/2019"),
                section2750_2020spr.FindEnrollment(10000019), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000006, 9, DateTime.Parse("1/21/2019"),
                section2750_2020spr.FindEnrollment(10000021), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000007, 8, DateTime.Parse("1/22/2019"),
                section2750_2020spr.FindEnrollment(10000023), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000008, 10, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000009, 9, DateTime.Parse("1/24/2019"),
                section2750_2020spr.FindEnrollment(10000013), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000010, 8, DateTime.Parse("1/25/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000011, 7, DateTime.Parse("1/26/2019"),
                section2750_2020spr.FindEnrollment(10000017), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000012, 8, DateTime.Parse("1/24/2019"),
                section2750_2020spr.FindEnrollment(10000019), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000013, 9, DateTime.Parse("1/25/2019"),
                section2750_2020spr.FindEnrollment(10000021), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000014, 10, DateTime.Parse("1/23/2019"),
                section2750_2020spr.FindEnrollment(10000023), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000015, 9, DateTime.Parse("1/28/2019"),
                section2750_2020spr.FindEnrollment(10000011), section2750_2020spr.FindAssignment("1C"));
            new AssignmentGrade(10000016, 8, DateTime.Parse("1/29/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1C"));
            new AssignmentGrade(10000018, 10, DateTime.Parse("1/26/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1D"));
            new AssignmentGrade(10000020, 50, DateTime.Parse("1/26/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("Q1"));

            Enrollment enr = section2750_2020spr.FindEnrollment(10000015);
            int totalPoints = enr.CalcTotalPoints();
            Assert.AreEqual(84, totalPoints);
        }



        [TestMethod]
        public void EnrollmentCalcGrade()
        {
            Department comc = this.school.FindDepartment("COMC");
            Course comc2750 = new Course(100003, "2750", "UML Modeling and Iterative Process", 2, comc);
            Term term2020spr = school.FindTerm(2020, TermsEnum.Spr);
            Section section2750_2020spr = new Section(100002, 24, comc2750, term2020spr);

            // Add Assignments
            new Assignment(10000001, "1A", "Worksheet, identify student grade info classes",
                10, DateTime.Parse("1/23/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000002, "1B", "UML domain model, library books",
                10, DateTime.Parse("1/29/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000003, "1C", "UML Student Info domain model w/associations",
                10, DateTime.Parse("1/30/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000004, "1D", "Modify 1B (Library system): add attributes & operations",
                10, DateTime.Parse("2/1/2020"), AssignmentTypesEnum.E, section2750_2020spr);
            new Assignment(10000005, "Q1", "Quiz 1",
                50, DateTime.Parse("2/2/2020"), AssignmentTypesEnum.Q, section2750_2020spr);

            // Add enrollments
            new Enrollment(10000003, GradeTypesEnum.AF, GradesEnum.Z, school.FindStudent(10000015), section2750_2020spr);

            // Add AssignmentGrades
            new AssignmentGrade(10000003, 8, DateTime.Parse("1/22/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1A"));
            new AssignmentGrade(10000010, 8, DateTime.Parse("1/25/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1B"));
            new AssignmentGrade(10000016, 8, DateTime.Parse("1/29/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1C"));
            new AssignmentGrade(10000018, 10, DateTime.Parse("1/26/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("1D"));
            new AssignmentGrade(10000020, 46, DateTime.Parse("1/26/2019"),
                section2750_2020spr.FindEnrollment(10000015), section2750_2020spr.FindAssignment("Q1"));

            Enrollment enr = section2750_2020spr.FindEnrollment(10000015);

            GradesEnum grade = enr.CalcGrade();
            Assert.AreEqual(GradesEnum.B, grade);
        }
    }
}
