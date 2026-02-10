using ECommerce.Entities;
using ECommerce.Models;
using ECommerce.Repositories;

namespace ECommerce.Services
{
    public class CategoryService(GenericRepository<Category> _categoryRepository)
    {
        /*Listar*/
        public async Task<IEnumerable<CategoryVM>>GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesVM = categories.Select(item => 
            new CategoryVM
            {
                CategoryId = item.CategoryId,
                Name = item.Name
            }
            ).ToList();

            return categoriesVM;
        }

        /*Agregar*/
        public async Task AddAsync(CategoryVM viewModel)
        {
            var entity = new Category
            {
                Name = viewModel.Name,
            };
            await _categoryRepository.AddAsync(entity);
        }

    }
}
