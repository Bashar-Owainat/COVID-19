using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Models.Interfaces
{
    public interface ITotalStatistics
    {
        Task<TotalStatistic> GetTotalStatistics();
    }
}
