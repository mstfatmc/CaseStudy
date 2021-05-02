using System.Collections.Generic;
using CaseStudy.Services.Model;

namespace CaseStudy.Responses
{
    public class GetCompaniesHttpResponse
    {
        public IEnumerable<Company> Companies { get; set; }
    }
}