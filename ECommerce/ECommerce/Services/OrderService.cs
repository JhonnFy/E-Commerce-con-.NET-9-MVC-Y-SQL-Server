using ECommerce.Entities;
using ECommerce.Models;
using ECommerce.Repositories;

namespace ECommerce.Services
{
    public class OrderService(OrderRepository _orderRepository) 
    {
        public async Task AddAsync(List<CartItemVM> cartItemVm, int userId)
        {
            Order order = new Order()
            {
                OrderDate = DateTime.Now,
                UserId = userId,
                TotalAmount = cartItemVm.Sum(x=>x.Price*x.Quantity),
                OrderItems = cartItemVm.Select(x=> new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            };

            await _orderRepository.AddAsync(order);

        }
    }
}
