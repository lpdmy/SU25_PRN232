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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _categoryRepo.GetAllAsync();

        public async Task<Category?> GetByIdAsync(int id)
            => await _categoryRepo.GetByIdAsync(id);

        public async Task<Category?> GetByNameAsync(string name)
            => await _categoryRepo.GetByNameAsync(name);

        public async Task CreateAsync(Category category)
            => await _categoryRepo.AddAsync(category);

        public async Task UpdateAsync(Category category)
            => await _categoryRepo.UpdateAsync(category);

        public async Task DeleteAsync(int id)
            => await _categoryRepo.DeleteAsync(id);
    }

}
