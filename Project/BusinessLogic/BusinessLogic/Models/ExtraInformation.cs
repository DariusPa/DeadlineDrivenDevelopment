using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class ExtraInformation
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public IList<string> Links { get; set; }
    }
}