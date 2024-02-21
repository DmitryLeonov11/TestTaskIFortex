using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User> GetUser()
        {
            return await _db.Users.OrderByDescending(u => u.Orders.Count).FirstAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.Where(u => u.Status.Equals(UserStatus.Inactive)).ToListAsync();
        }
    }
}
