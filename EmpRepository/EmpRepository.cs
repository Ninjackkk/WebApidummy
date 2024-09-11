// EmpRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApidummy.Data;
using WebApidummy.Models;

namespace WebApidummy.Repositories
{
    public class EmpRepository : IEmpRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Emp emp)
        {
            await _context.EmpDetails.AddAsync(emp);
            await _context.SaveChangesAsync();
        }

        public async Task AddMultipleAsync(IEnumerable<Emp> emps)
        {
            await _context.EmpDetails.AddRangeAsync(emps);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Emp>> GetAllAsync()
        {
            return await _context.EmpDetails.ToListAsync();
        }

        public async Task<Emp> GetByIdAsync(int id)
        {
            return await _context.EmpDetails.FindAsync(id);
        }

        public async Task UpdateAsync(Emp emp)
        {
            _context.EmpDetails.Update(emp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _context.EmpDetails.FindAsync(id);
            if (emp != null)
            {
                _context.EmpDetails.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMultipleAsync(IEnumerable<int> ids)
        {
            var emps = await _context.EmpDetails.Where(e => ids.Contains(e.Id)).ToListAsync();
            _context.EmpDetails.RemoveRange(emps);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Emp>> SearchAsync(string searchTerm)
        {
            return await _context.EmpDetails
                .Where(x => x.Name.Contains(searchTerm) ||
                            x.Dept.Contains(searchTerm) ||
                            x.Salary.ToString().Contains(searchTerm) ||
                            x.Id.ToString().Contains(searchTerm))
                .ToListAsync();
        }
    }
}
