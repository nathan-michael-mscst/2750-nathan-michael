using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo3B
{
    public partial class Student
    {
        public Student(string lastName, string firstName, 
            string loginName, string emailAddress, string phoneNumber, 
            string address, string city, string state, string zipCode, School school)
        {
            this.Enrollments = new List<Enrollment>();
            //this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.LoginName = loginName;
            this.EmailAddress = emailAddress;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.School = school;
            this.School.Students.Add(this);
        }

        public Enrollment FindEnrollment(int sectionId)
        {
            Enrollment foundEnrollment = null;
            foreach (Enrollment e in this.Enrollments)
            {
                if (e.Section.Id == sectionId)
                {
                    foundEnrollment = e;
                    break;
                }
            }
            return foundEnrollment;
        }
    }
}
