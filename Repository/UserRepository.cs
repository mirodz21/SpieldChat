using API.Data;
using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.User.Include(p => p.Photos).ToListAsync();
        }

        public Task<User> GetAllUserById(int id)
        {
            return _context.User.Include(p => p.Photos).SingleOrDefaultAsync(x =>x.Id == id);
        }

        public Task<User> GetAllUserByName(string username)
        {
            return _context.User.Include(p =>p.Photos).SingleOrDefaultAsync(x =>x.UserName == username);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            _context.Update(user).State = EntityState.Modified;
        }
    }
}
