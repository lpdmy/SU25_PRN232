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

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Courses
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetByUserIdAsync(int userId)
        {
            return await _context.Courses
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }

}
