namespace ECommerce.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; } /*Pk*/
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } 

        /*¿A que Order Pertenece*/
        public Order? Order { get; set; } /*Fk*/
        /*¿Cual Es El Listado De Los Productos?*/
        public Product? Product { get; set; } /*Fk*/

    }
}
