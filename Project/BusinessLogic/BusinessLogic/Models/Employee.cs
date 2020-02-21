using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class Employee
    {
        public string FirstName { get; set;}
        public string Surname { get; set; }
        public Role Role { get; set; }

        //public Restriction Restriction { get; set; }
    }
}
