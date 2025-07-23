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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepo;

        public CourseService(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
            => await _courseRepo.GetAllAsync();

        public async Task<Course?> GetByIdAsync(int id)
            => await _courseRepo.GetByIdAsync(id);

        public async Task<IEnumerable<Course>> GetByCategoryIdAsync(int categoryId)
            => await _courseRepo.GetByCategoryIdAsync(categoryId);

        public async Task<IEnumerable<Course>> GetByUserIdAsync(int userId)
            => await _courseRepo.GetByUserIdAsync(userId);

        public async Task CreateAsync(Course course)
            => await _courseRepo.AddAsync(course);

        public async Task UpdateAsync(Course course)
            => await _courseRepo.UpdateAsync(course);

        public async Task DeleteAsync(int id)
            => await _courseRepo.DeleteAsync(id);
    }

}
