using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    using DataAccess.Models;
    using DataAccess;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetByUserIdAsync(int userId)
        {
            return await _context.Enrollments
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }
    }

}
