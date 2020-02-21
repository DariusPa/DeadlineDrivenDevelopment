using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class Team
    {
        public string Name { get; set; }
        public TeamLead TeamLead { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
