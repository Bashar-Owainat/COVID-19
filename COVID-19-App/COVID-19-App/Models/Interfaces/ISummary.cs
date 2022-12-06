using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Models.Interfaces
{
    public interface ISummary
    {
        public Task<SummaryDTO> AddSummary(SummaryDTO summaryDTO);
        public Task<List<SummaryDTO>> GetSummariesFromDB();
        public Task DeleteSummary(string name);
        public Task<List<SummaryDTO>> GetSummary();
       // public Task<CountrySummary> GetSpecificSummary(string ID);

    }
}
