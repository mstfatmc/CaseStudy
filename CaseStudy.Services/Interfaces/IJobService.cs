using CaseStudy.Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Services.Interfaces
{
    public interface IJobService
    {
        Task<SearchJobServiceResponse> SearchJobs(string keyword);
    }
}
