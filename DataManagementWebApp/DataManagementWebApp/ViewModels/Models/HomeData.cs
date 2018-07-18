using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DataManagementWebApp.Models
{
    public class HomeData
    {

        public DayProduction Production { get; set; }

        [DataType(DataType.Date)]
        public DateTime Today { get; set; }

        public String Name { get; set; }

        public decimal Value { get; set; }
    }

    public class DayProduction
    {
        public String Location { get; set; }

        public List<Detail> LstProdDetail { get; set; }
    }

    public class Detail
    {
        public String Name { get; set; }

        public String Unit { get; set; }

        public decimal Value { get; set; }

    }

   
}