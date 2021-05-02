using CaseStudy.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Services.Responses
{
    public class SearchJobServiceResponse
    {
        public IEnumerable<Job> Jobs { get; set; }

        public SearchJobServiceResponse()
        {
            Jobs = new List<Job>();
        }
    }
}
