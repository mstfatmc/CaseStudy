using CaseStudy.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Dal.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<JobEntity>> GetAll();
        Task<JobEntity> Get(int id);
        Task<JobEntity> Create(JobEntity company);
        Task Update(JobEntity company);
        Task Delete(int id);
    }
}
