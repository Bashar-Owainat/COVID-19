using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Models
{
    [Keyless]
    public class CountryData
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Cases { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }

    }
}
