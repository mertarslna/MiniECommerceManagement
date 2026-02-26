using Microsoft.EntityFrameworkCore;
using MiniECommerce.DataAccess.Context;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Order GetOrderWithDetails(int id)
        {
            return _context.Order
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.Id == id);
        }

    }

}
