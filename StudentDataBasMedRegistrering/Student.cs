using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataBasMedRegistrering
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }

        public override string ToString()
        {
            return $"First name : {FirstName}\n" +
                $"Last name : {LastName}\n" +
                $"City {City}";
        }
    }
}
