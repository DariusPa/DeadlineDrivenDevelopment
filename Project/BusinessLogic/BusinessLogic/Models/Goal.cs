using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public abstract class Goal {
        public Topic Topic { get; set; }
        public Employee Employee { get; set; }

    }
}

