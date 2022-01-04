using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeMVC.Models
{
    public class Student
    {
       public string Firstname;
       public string LastName;
       public DateTime BirthDay;
       public string Email;
      public  int YearOfStudy;

      public static List<Student> myStudent=new List<Student>();
        public Student(string firstname, string lastName, DateTime BirthDay, string email, int yearOfStudy)
        {
           this.Firstname = firstname;
          this.LastName = lastName;
           this.BirthDay =BirthDay;
           this.Email = email;
           this.YearOfStudy = yearOfStudy;
        }
    }
}