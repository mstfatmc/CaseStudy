namespace CaseStudy.Services.Requests
{
    public class PutCompanyServiceRequest
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int AdvertisementLimit { get; set; }
    }
}