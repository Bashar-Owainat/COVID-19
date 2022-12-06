using COVID_19_App.covid19;
using COVID_19_App.Data;
using COVID_19_App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Models.Services
{
    public class SummaryServices : ISummary
    {
        private static IGetSummary _getSummary;
       /// private static IGetSpecificSummary _getSpecificSummary;

        private readonly COVID19DbContext _context;

        public SummaryServices(IGetSummary getSummary, COVID19DbContext context)
        {
            _getSummary = getSummary;
            _context = context;
        }

        //public async Task<SummaryDTO> AddSummary(string id)
        //{
        //    CountrySummary countrySummary = await _getSpecificSummary.ReturnSpecificSummary(id);

        //    SummaryDTO summaryDTO = new SummaryDTO
        //    {
        //        Country = countrySummary.Country,
        //        TotalConfirmed = countrySummary.TotalConfirmed,
        //        Date = countrySummary.Date,
        //        TotalDeaths = countrySummary.TotalDeaths,
        //        TotalRecovered = countrySummary.TotalRecovered,
        //    };

        //    _context.Entry(countrySummary).State = EntityState.Added;
        //    await _context.SaveChangesAsync();
        //    return summaryDTO;
        //}

        public async Task<SummaryDTO> AddSummary(SummaryDTO summaryDTO)
        {
           
            CountrySummary countrySummary = new CountrySummary
            {
                ID = "",
                Country = summaryDTO.Country,
                TotalConfirmed = summaryDTO.TotalConfirmed,
                TotalDeaths = summaryDTO.TotalDeaths,
                TotalRecovered = summaryDTO.TotalRecovered,
                Date = summaryDTO.Date,
                CountryCode = null,
                NewConfirmed = 0,
                NewDeaths = 0,
                NewRecovered = 0,
                Premium = null,
                Slug = null

            };
            _context.Entry(countrySummary).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return summaryDTO;
        }

        public async Task<List<SummaryDTO>> GetSummary()
        {
            return await _getSummary.ReturnSummary();
        }


        //public async Task<CountrySummary> GetSpecificSummary(string id)
        //{
        //    return await _getSpecificSummary.ReturnSpecificSummary(id);
        //}

        public async Task DeleteSummary(string name)
        {
            CountrySummary countrySummary =  _context.CountrySummaries.Where(c => c.Country == name).FirstOrDefault();
            _context.Entry(countrySummary).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<SummaryDTO>> GetSummariesFromDB()
        {
            return await _context.CountrySummaries.Select(Summary => new SummaryDTO { Country = Summary.Country,
            TotalConfirmed = Summary.TotalConfirmed,
            Date = Summary.Date,
            TotalDeaths = Summary.TotalDeaths,
            TotalRecovered = Summary.TotalRecovered
            }).ToListAsync();
        }
    }
}
