using COVID_19_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.covid19
{
    public interface IGetSpecificSummary
    {
        public Task<CountrySummary> ReturnSpecificSummary(string ID);
    }
}
