using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task<Enrollment?> GetByIdAsync(int id);
        Task<IEnumerable<Enrollment>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId);
        Task EnrollAsync(Enrollment enrollment);
        Task DeleteAsync(int id);
    }

}
