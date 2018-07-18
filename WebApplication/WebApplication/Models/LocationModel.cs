using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class LocationModel
    {
        public List<Location> LstLocations { get; set; }
    }

    public class Location
    {
        public String Name { get; set; }

        public bool Online { get; set; }

        public DateTime LastAlive { get; set; }

    }
}