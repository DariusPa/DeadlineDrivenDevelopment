using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    //TODO: should be available to set globally/individually
    public struct Restriction
    {
        public int ConsecutiveDays { get; set; }
        public int MonthlyMaxDays { get; set; }
        public int YearlyMaxDays { get; set; }
    }
}
