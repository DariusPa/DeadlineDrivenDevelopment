using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class SubTopic: Topic
    {
        public Topic MainTopic { get; set; }
    }
}
