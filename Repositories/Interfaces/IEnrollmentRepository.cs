using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<IEnumerable<Enrollment>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId);
    }

}
