using System;

namespace CaseStudy.Requests
{
    public class PostCompanyJobAdvertisementHttpRequest
    {
        public string Description { get; set; }

        public string Position { get; set; }

        public string WorkType { get; set; }

        public string Benefits { get; set; }

        public decimal Salary { get; set; }
    }
}