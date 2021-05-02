using CaseStudy.Dal.Context;
using CaseStudy.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Dal.Repositories
{
     

    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationContext _context;

        public CompanyRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CompanyEntity> Create(CompanyEntity company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompanyEntity>> GetAll()
        {
            return await _context.Companies.AsNoTracking().ToListAsync();
        }

        public async Task<CompanyEntity> Get(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(x=> x.CompanyId == id);
        }

        public async Task Update(CompanyEntity company)
        {
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
