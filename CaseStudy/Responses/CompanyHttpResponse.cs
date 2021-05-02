using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Responses
{
    public class CompanyHttpResponse
    {
            public int CompanyId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public int AdvertisementLimit { get; set; }       
    }
}
