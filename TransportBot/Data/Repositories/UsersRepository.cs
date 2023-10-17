using Microsoft.EntityFrameworkCore;
using TransportBot.Entities;
using TransportBot.Interfaces;

namespace TransportBot.Data.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

       public async Task<UserEntity> GetUserAsync(int id)
        {
            return await _context.Users.AsNoTracking()
            .Include(u => u.Addresses)           
            .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<UserEntity[]> GetUsersAsync()
        {
            var query = _context.Users.Include(d => d.Addresses).AsQueryable();
            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<bool> CreateAsync(UserEntity user)
        {
           _context.Users.
           Add(user).State = EntityState.Added;
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(UserEntity user)
        {            
           _context.Entry(user).State = EntityState.Modified;
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            _context.Entry(userToDelete).State = EntityState.Deleted; 
            return await _context.SaveChangesAsync() > 0;
        }    
    }
}