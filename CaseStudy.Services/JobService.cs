using CaseStudy.Dal.Repositories;
using CaseStudy.Services.Interfaces;
using CaseStudy.Services.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<SearchJobServiceResponse> SearchJobs(string keyword)
        {
            // validate inputs
            if (string.IsNullOrEmpty(keyword))
            {
                throw new ValidationException("Search keyword required");
            }

            var searchJobServiceResponse = new SearchJobServiceResponse();

            // get data from repository
            var jobEntities = await _jobRepository.GetAll();
            jobEntities = jobEntities
                .Where(t => t.ExpireDate > DateTime.Now && t.Description.Contains(keyword) || t.Position.Contains(keyword))
                .OrderByDescending(t=>t.Quality);

            if (jobEntities != null && !jobEntities.Any())
            {
                return searchJobServiceResponse;
            }

            searchJobServiceResponse.Jobs = jobEntities.Select(x => new Model.Job()
            {
                Benefits = x.Benefits,
                Company = new Model.JobListCompany()
                {
                    Name = x.Company.Name,
                    PhoneNumber = x.Company.PhoneNumber
                },
                Description = x.Description,
                ExpireDate = x.ExpireDate,
                Position = x.Position,
                Quality = x.Quality,
                Salary = x.Salary,
                WorkType = x.WorkType
            });

            return searchJobServiceResponse;
        }
    }
}
