using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DayProductionModel
    {
        public DayProduction Production { get; set; }

        public DateTime SelectedDate { get; set; }

    }

    public class DayProduction
    {
        public String Location { get; set; }

        public List<ProductionDetail> LstProdDetail { get; set; }
    }

    public class ProductionDetail
    {
        public String Name { get; set; }

        public String Location { get; set; }

        public String Unit { get; set; }

        public decimal Value { get; set; }

        public DateTime ProdDate { get; set; }

        public String StrProdDate { get; set; }

    }
}