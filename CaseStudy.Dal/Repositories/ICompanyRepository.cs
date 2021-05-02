using CaseStudy.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Dal.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyEntity>> GetAll();
        Task<CompanyEntity> Get(int id);
        Task<CompanyEntity> Create(CompanyEntity company);
        Task Update(CompanyEntity company);
        Task Delete(int id);
    }
}
