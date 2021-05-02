using CaseStudy.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Responses
{
    public class SearchJobHttpResponse
    {
        public IEnumerable<Job> Jobs { get; set; }
    }
}
