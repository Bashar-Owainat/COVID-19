using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Models
{
    
    public class CountryDTO
    {
        
        public string Date { get; set; }
        public int Cases { get; set; }
    }
}
