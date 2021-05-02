using System;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Dal.Entities;
using CaseStudy.Dal.Repositories;
using CaseStudy.Services.Constants;
using CaseStudy.Services.Interfaces;
using CaseStudy.Services.Model;
using CaseStudy.Services.Requests;
using CaseStudy.Services.Responses;
using CaseStudy.Services.Validations;
using FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace CaseStudy.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<GetCompanyServiceResponse> GetCompanies(int offset, int limit)
        {
            // validate inputs
            if (offset < 0)
            {
                throw new ValidationException("Offset is invalid, must be greater then or equal to 0");
            }

            if (limit > 100)
            {
                throw new ValidationException("Limit is invalid, must be less then or equal to 100");
            }
            
            var getCompanyServiceResponse = new GetCompanyServiceResponse();
            
            // get data from repository
            var companyEntities = await _companyRepository.GetAll();

            if (companyEntities != null && !companyEntities.Any())
            {
                return getCompanyServiceResponse;
            }

            var companies = companyEntities.Select(x => new Company()
            {
                CompanyId = x.CompanyId,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                AdvertisementLimit = x.AdvertisementLimit
            });

            getCompanyServiceResponse.Companies = companies;
            return getCompanyServiceResponse;
        }

        public async Task<Company> GetCompany(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ValidationException("Company Id can not be less or equal to 0");
            }
            var getCompanyServiceResponse = new Company();

            var companyEntity = await _companyRepository.Get(companyId);

            if (companyEntity == null)
            {
                return getCompanyServiceResponse;
            }

            getCompanyServiceResponse = new Company()
            {
                Address = companyEntity.Address,
                Name = companyEntity.Name,
                PhoneNumber = companyEntity.PhoneNumber,
                AdvertisementLimit = companyEntity.AdvertisementLimit,
                CompanyId = companyEntity.CompanyId
            };
            

            return getCompanyServiceResponse;
        }

        public async Task<CreateCompanyServiceResponse> CreateCompany(CreateCompanyServiceRequest createCompanyServiceRequest)
        {
            var companyValidator = new CompanyValidator();
            await companyValidator.ValidateAndThrowAsync(createCompanyServiceRequest);

            var exists = await _companyRepository.GetAll();
            var check = exists.Any(t => t.PhoneNumber == createCompanyServiceRequest.PhoneNumber);
            if (check)
            {
                throw new ValidationException("Company with this phone number already exists");
            }

            var company = await _companyRepository.Create(new CompanyEntity()
            {
                Name = createCompanyServiceRequest.Name,
                Address = createCompanyServiceRequest.Address,
                PhoneNumber = createCompanyServiceRequest.PhoneNumber,
                AdvertisementLimit = ServiceConstants.AdvertisementLimit
            });

            var createCompanyServiceResponse = new CreateCompanyServiceResponse
            {
                CompanyId = company.CompanyId
            };

            return createCompanyServiceResponse;
        }

        public async Task UpdateCompany(PutCompanyServiceRequest putCompanyServiceRequest)
        {
            var companyEntity = await _companyRepository.Get(putCompanyServiceRequest.CompanyId);

            if (companyEntity != null)
            {
                await _companyRepository.Update(new CompanyEntity()
                {
                    CompanyId = putCompanyServiceRequest.CompanyId,
                    Name = putCompanyServiceRequest.Name,
                    Address = putCompanyServiceRequest.Address,
                    PhoneNumber = putCompanyServiceRequest.PhoneNumber,
                    AdvertisementLimit = putCompanyServiceRequest.AdvertisementLimit
                });
            }
            else
            {
                throw new ArgumentNullException("Company is not found");
            }
        }

        public async Task CreateCompanyAdvertisement(PostCompanyJobAdvertisementServiceRequest postCompanyJobAdvertisementServiceRequest)
        {
            var companyEntity = await _companyRepository.Get(postCompanyJobAdvertisementServiceRequest.CompanyId);

            if (companyEntity ==null)
            {
                throw new ArgumentNullException("Company not found");
            }

            if (companyEntity.AdvertisementLimit == 0)
            {
                throw new ValidationException("Company AdvertisementLimit is reached");
            }

            //TODO : nedense çalışmıyor. link: https://docs.microsoft.com/en-us/ef/core/saving/related-data
            companyEntity.JobEntities.Add(new JobEntity()
            {
                Benefits = postCompanyJobAdvertisementServiceRequest.Benefits,
                Salary = postCompanyJobAdvertisementServiceRequest.Salary,
                WorkType = postCompanyJobAdvertisementServiceRequest.WorkType,
                ExpireDate = DateTime.Now.AddDays(15),
                Description = postCompanyJobAdvertisementServiceRequest.Description,
                Position = postCompanyJobAdvertisementServiceRequest.Position,
                Quality = CalculationService.CalculateJobQualityScore(postCompanyJobAdvertisementServiceRequest),
                Company = companyEntity
            });

            companyEntity.AdvertisementLimit--;                      

            await _companyRepository.Update(companyEntity);
        }
    }
}