using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CaseStudy.Dal;
using CaseStudy.Dal.Entities;
using CaseStudy.Dal.Repositories;
using CaseStudy.Requests;
using CaseStudy.Responses;
using CaseStudy.Services.Interfaces;
using CaseStudy.Services.Requests;
using CaseStudy.Services.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseStudy.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        [ProducesResponseType(typeof(GetCompaniesHttpResponse),(int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(JsonResult),(int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCompanies(int offset, int limit)
        {
            var getCompanyServiceResponse = await _companyService.GetCompanies(offset, limit);

            var getCompanyHttpResponse = new GetCompaniesHttpResponse();
            
            if (getCompanyServiceResponse != null && getCompanyServiceResponse.Companies.Any())
            {
                getCompanyHttpResponse.Companies = getCompanyServiceResponse.Companies;
            }
            else
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }

            return StatusCode((int) HttpStatusCode.OK, getCompanyHttpResponse);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCompaniesHttpResponse),(int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(JsonResult),(int) HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var getCompanyServiceResponse = await _companyService.GetCompany(id);

            if (getCompanyServiceResponse == null)
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }

            var getCompanyHttpResponse = new CompanyHttpResponse
            { 
                Address = getCompanyServiceResponse.Address,
                AdvertisementLimit = getCompanyServiceResponse.AdvertisementLimit,
                CompanyId = getCompanyServiceResponse.CompanyId,
                Name = getCompanyServiceResponse.Name,
                PhoneNumber = getCompanyServiceResponse.PhoneNumber
            };

            return StatusCode((int) HttpStatusCode.OK, getCompanyHttpResponse);
        }

        // POST api/<CompanyController>
        [HttpPost]
        [ProducesResponseType(typeof(PostCompanyHttpResponse),(int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(JsonResult),(int) HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Post([FromBody] PostCompanyHttpRequest postCompanyHttpRequest)
        {

            var createCompanyServiceResponse = await _companyService.CreateCompany(new CreateCompanyServiceRequest()
            {
                Name = postCompanyHttpRequest.Name,
                PhoneNumber = postCompanyHttpRequest.PhoneNumber,
                Address = postCompanyHttpRequest.Address
            });

            var postCompanyHttpResponse = new PostCompanyHttpResponse
            {
                CompanyId = createCompanyServiceResponse.CompanyId
            };

            return StatusCode((int) HttpStatusCode.Created, postCompanyHttpResponse);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] PutCompanyHttpRequest putCompanyHttpRequest)
        {

            await _companyService.UpdateCompany(new PutCompanyServiceRequest()
            {
                CompanyId = id,
                Name = putCompanyHttpRequest.Name,
                Address = putCompanyHttpRequest.Address,
                PhoneNumber = putCompanyHttpRequest.PhoneNumber,
                AdvertisementLimit = putCompanyHttpRequest.AdvertisingLimit
            });

            return StatusCode((int)HttpStatusCode.Accepted);
        }

        [HttpPost("{id}/jobs")]
        public async Task<ActionResult> Post([FromRoute] int id,[FromBody] PostCompanyJobAdvertisementHttpRequest postCompanyJobAdvertisement)
        {            
              await _companyService.CreateCompanyAdvertisement(new PostCompanyJobAdvertisementServiceRequest()
              {
                  CompanyId = id,
                  Salary = postCompanyJobAdvertisement.Salary,
                  Benefits = postCompanyJobAdvertisement.Benefits,
                  Description = postCompanyJobAdvertisement.Description,
                  Position = postCompanyJobAdvertisement.Position,
                  WorkType = postCompanyJobAdvertisement.WorkType
              });
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
