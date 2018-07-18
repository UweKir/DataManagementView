using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ProductionTable
{
    public class ProductionTableLine
    {
        public String Group { get; set; }

        public String Name { get; set; }

        public Decimal Runtime { get; set; }

        public Decimal Tons { get; set; }

        public Decimal TonsInHour { get; set; }
    }
}