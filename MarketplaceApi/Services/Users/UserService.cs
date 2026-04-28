using MarketplaceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> UpdateNameAsync(int userId, string name)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                return false;

            user.UserName = name;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
