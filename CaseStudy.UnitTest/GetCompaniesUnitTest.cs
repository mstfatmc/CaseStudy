using CaseStudy.Dal.Entities;
using CaseStudy.Dal.Repositories;
using CaseStudy.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace CaseStudy.UnitTest
{
    public class GetCompaniesUnitTest
    {
        private readonly CompanyService _companyService;

        public GetCompaniesUnitTest()
        {
            var companyRepository = new Mock<ICompanyRepository>();
            companyRepository.Setup(x => x.GetAll().Result).Returns(() => new List<CompanyEntity>());
            _companyService = new CompanyService(companyRepository.Object);
        }

        [Fact]
        public void GetCompanies()
        {
            var companies =  _companyService.GetCompanies(0, 10).Result;
            Assert.NotNull(companies);
        }

        [Fact]
        public void GetCompaniesLimit()
        {
            Assert.Throws<ValidationException>(() => _companyService.GetCompanies(-1, 10).Result);
        }


        [Fact]
        public void GetCompaniesOffset()
        {
            Assert.Throws<ValidationException>(() => _companyService.GetCompanies(1, 101).Result);
        }
    }
}
