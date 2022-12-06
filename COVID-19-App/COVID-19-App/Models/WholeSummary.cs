using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Models
{
    public class WholeSummary
    {
        public string ID { get; set; }
        public string Message { get; set; }
        [NotMapped]
        public Global Global { get; set; }
        public List<CountrySummary> Countries { get; set; }

        public string Date { get; set; }
    }

    [Keyless]
    public class Global
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }

        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public string Date { get; set; }


    }

    public class CountrySummary
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Slug { get; set; }
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public string Date { get; set; }

        #nullable enable
        public Premium? Premium { get; set; }
        #nullable disable

    }

    public class Premium
    {
       #nullable enable
        public string? ID { get; set; }
       #nullable disable
    }
}
