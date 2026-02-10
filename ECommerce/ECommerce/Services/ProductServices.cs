using ECommerce.Entities;
using ECommerce.Models;
using ECommerce.Repositories;

namespace ECommerce.Services
{
    public class ProductServices(
    
        /*Dependencias*/
        GenericRepository<Category> _categoryRepository,
        GenericRepository<Product> _productRepository,

        /*Eniva Las Imagenes a wwwroot*/
        IWebHostEnvironment _webHostEnvironment
        )

    {
        /*Metodo Para Listar Productos*/
        public async Task<IEnumerable<ProductVM>>GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
        }


    }
            







    }
}
