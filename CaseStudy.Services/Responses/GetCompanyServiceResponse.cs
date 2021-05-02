using System.Collections.Generic;
using CaseStudy.Services.Model;

namespace CaseStudy.Services.Responses
{
    public class GetCompanyServiceResponse
    {
        public IEnumerable<Company> Companies { get; set; }

        public GetCompanyServiceResponse()
        {
            Companies = new List<Company>();
        }
    }
}