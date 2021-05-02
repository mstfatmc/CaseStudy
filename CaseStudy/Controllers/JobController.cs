using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CaseStudy.Dal;
using CaseStudy.Dal.Entities;
using CaseStudy.Dal.Repositories;
using CaseStudy.Requests;
using CaseStudy.Responses;
using CaseStudy.Services.Interfaces;
using CaseStudy.Services.Requests;
using CaseStudy.Services.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseStudy.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET: api/<JobController>
        [HttpGet]
        public async Task<SearchJobHttpResponse> SearchAsync(string keyword)
        {
            var searchJobServiceResponse = await _jobService.SearchJobs(keyword);

            var searchJobHttpResponse = new SearchJobHttpResponse();

            if (searchJobServiceResponse != null && searchJobServiceResponse.Jobs.Any())
            {
                searchJobHttpResponse.Jobs = searchJobServiceResponse.Jobs;
            }
              
            return searchJobHttpResponse;
        }
    }
}
