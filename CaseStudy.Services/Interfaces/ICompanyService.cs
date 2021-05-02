using System.Collections.Generic;
using System.Threading.Tasks;
using CaseStudy.Dal.Entities;
using CaseStudy.Services.Model;
using CaseStudy.Services.Requests;
using CaseStudy.Services.Responses;

namespace CaseStudy.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<GetCompanyServiceResponse> GetCompanies(int offset, int limit);
        Task<Company> GetCompany(int companyId);
        Task<CreateCompanyServiceResponse> CreateCompany(CreateCompanyServiceRequest createCompanyServiceRequest);
        Task UpdateCompany(PutCompanyServiceRequest putCompanyServiceRequest);
        Task CreateCompanyAdvertisement(PostCompanyJobAdvertisementServiceRequest postCompanyJobAdvertisementServiceRequest);
    }
}