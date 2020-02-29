using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class LearningDay
    {
        public Topic Topic { get; set; }
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public List<ExtraInformation> ExtraInformation { get; set; }
    }
}
