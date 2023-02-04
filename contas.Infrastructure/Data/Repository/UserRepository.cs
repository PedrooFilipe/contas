using contas_api_model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using contas_api_model.Entity;

namespace contas_api_model.Repository
{
    public class UserRepository : IUserRepository
    {
        private MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task Save(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User newUser, int oldUserId)
        {
            try
            {
                User oldUser = await this.Find(oldUserId);

                if (oldUser == null)
                {
                    throw new Exception("Conta não encontrada!");
                }

                newUser.Id = oldUser.Id;

                _context.Entry(newUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> Find(int id)
        {
            return await _context.Users.Where(c => c.Id == id).AsNoTracking().SingleOrDefaultAsync();
        }
        
        public async Task<User> FindByEmail(string email)
        {
            return await _context.Users.Where(c => c.Email.Equals(email)).AsNoTracking().SingleOrDefaultAsync();
        }

    }
}
