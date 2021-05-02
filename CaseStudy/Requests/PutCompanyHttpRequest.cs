namespace CaseStudy.Requests
{
    public class PutCompanyHttpRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int AdvertisingLimit { get; set; }
    }
}