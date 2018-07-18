using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DayUsageModel
    {
    }

    public class UsageDetail
    {
        public String Name { get; set; }

        public String Device { get; set; }

        public String Location { get; set; }

        public String Unit { get; set; }

        public decimal Value { get; set; }

    }
}