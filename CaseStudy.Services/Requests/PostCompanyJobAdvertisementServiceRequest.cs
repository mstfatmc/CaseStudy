namespace CaseStudy.Services.Requests
{
    public class PostCompanyJobAdvertisementServiceRequest
    {
        public int CompanyId { get; set; }
        public string Description { get; set; }

        public string Position { get; set; }

        public int Quality { get; set; }

        public string WorkType { get; set; }

        public string Benefits { get; set; }

        public decimal Salary { get; set; }
    }
}