using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Course>> GetByUserIdAsync(int userId);
    }

}
