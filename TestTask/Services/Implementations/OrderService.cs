using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;

        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Order> GetOrder()
        {
            return await _db.Orders.OrderByDescending(o => o.Quantity * o.Price).FirstAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _db.Orders.Where(o => o.Quantity > 10).ToListAsync();
        }
    }
}
