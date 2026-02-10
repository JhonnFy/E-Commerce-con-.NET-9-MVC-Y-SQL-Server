using ECommerce.Entities;
using ECommerce.Models;
using ECommerce.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

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
        /*Metodo Para Listar Productos-Cat*/
        public async Task<IEnumerable<ProductVM>>GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync(
                includes: new Expression<Func<Product, object>>[] {x => x.Category!}
                );

            var productVM = products.Select(item =>
                new ProductVM
                {
                    ProductId = item.ProductId,
                    Category = new CategoryVM
                    {
                        CategoryId = item.Category!.CategoryId,
                        Name = item.Category!.Name,
                    },
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Stock = item.Stock,
                    ImageName = item.ImageName,
                }).ToList();

            return productVM;
        }
    

        //Metodo Que Retorna Un Producto Por Id
        public async Task<ProductVM>GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var categories = await _categoryRepository.GetAllAsync();

            var productVM = new ProductVM();

            if(product != null)
            {
                productVM = new ProductVM
                {
                    ProductId = product.ProductId,
                    Category = new CategoryVM
                    {
                        CategoryId = product.Category!.CategoryId,
                        Name = product.Category.Name,
                    },
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Stock = product.Stock,
                    ImageName = product.ImageName
                };
            }

            productVM.Categories = categories.Select(item => new SelectListItem
            {
                Value = item.CategoryId.ToString(),
                Text = item.Name,
            }).ToList();

            return productVM;
        }





    }
}
