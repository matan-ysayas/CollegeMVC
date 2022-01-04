using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeMVC.Models
{
    public class Professor
    {
        public string FirstName;
        public string LastName;
        public string Subject;
        public string Email;
        public int Salary;

        public Professor(string firstName, string lastName, string subject, string email, int salary)
        {
           this.FirstName = firstName;
            this.LastName = lastName;
           this.Subject = subject;
           this.Email = email;
           this.Salary = salary;
        }
    }
}