using CaseStudy.Dal.Context;
using CaseStudy.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Dal.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationContext _context;

        public JobRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<JobEntity> Create(JobEntity company)
        {
            _context.Jobs.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobEntity>> GetAll()
        {
            return await _context.Jobs.Include(c=>c.Company).ToListAsync();
        }

        public async Task<JobEntity> Get(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task Update(JobEntity company)
        {
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
