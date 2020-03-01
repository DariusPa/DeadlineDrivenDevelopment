using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class Topic
    {
        public string Title { get; set; }
        public List<ExtraInformation> ExtraInformation { get; set; }
        public List<Topic> Subtopics { get; set; }
    }
}
