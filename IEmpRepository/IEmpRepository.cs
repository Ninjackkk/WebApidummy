// IEmpRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApidummy.Models;

namespace WebApidummy.Repositories
{
    public interface IEmpRepository
    {
        Task AddAsync(Emp emp);
        Task AddMultipleAsync(IEnumerable<Emp> emps);
        Task<IEnumerable<Emp>> GetAllAsync();
        Task<Emp> GetByIdAsync(int id);
        Task UpdateAsync(Emp emp);
        Task DeleteAsync(int id);
        Task DeleteMultipleAsync(IEnumerable<int> ids);
        Task<IEnumerable<Emp>> SearchAsync(string searchTerm);
    }
}
