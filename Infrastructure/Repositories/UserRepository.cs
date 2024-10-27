using Domain.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) => _context = context;
        
        public async Task<List<User>> GetAll()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<User?> GetById(Guid id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception("User not found");
        
            return user;
        }
        
        public async Task<User?> GetByEmail(string email)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email) ?? throw new Exception("User not found");
            
            return user;
        }
        
        public async Task<User> Add(User user)
        {
            _context.Users.Add(user);
            
            await _context.SaveChangesAsync();
            
            return user;
        }

        public async Task<User> Update(Guid id, User user)
        {
            var savedUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (savedUser != null)
            {
                savedUser.Name = user.Name;
                savedUser.Bio = user.Bio;
                savedUser.Skills = user.Skills;

                await _context.SaveChangesAsync();

                return savedUser;
            }
            
            throw new Exception("User not found.");
        }
        
        public async Task Delete(Guid id)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
