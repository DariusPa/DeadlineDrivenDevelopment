using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public struct Comment
    {
        public Employee Author { get; set; }
        public LearningDay Day { get; set; }
        public string Content { get; set; }
        public List<string> Links { get; set; }

        public Comment(Employee author, LearningDay day, string content, List<string> links)
        {
            Author = author;
            Day = day;
            Content = content;
            Links = links;
        }
    }
}
