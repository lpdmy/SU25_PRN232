using DataAccess.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollRepo;

        public EnrollmentService(IEnrollmentRepository enrollRepo)
        {
            _enrollRepo = enrollRepo;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
            => await _enrollRepo.GetAllAsync();

        public async Task<Enrollment?> GetByIdAsync(int id)
            => await _enrollRepo.GetByIdAsync(id);

        public async Task<IEnumerable<Enrollment>> GetByUserIdAsync(int userId)
            => await _enrollRepo.GetByUserIdAsync(userId);

        public async Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId)
            => await _enrollRepo.GetByCourseIdAsync(courseId);

        public async Task EnrollAsync(Enrollment enrollment)
            => await _enrollRepo.AddAsync(enrollment);

        public async Task DeleteAsync(int id)
            => await _enrollRepo.DeleteAsync(id);
    }

}
