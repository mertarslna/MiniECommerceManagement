using Microsoft.EntityFrameworkCore;
using MiniECommerce.DataAccess.Context;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Concrete
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context) { }
    }
}