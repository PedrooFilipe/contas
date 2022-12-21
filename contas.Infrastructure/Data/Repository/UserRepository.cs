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
        private Contexto _contexto;

        public UserRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Save(User user)
        {
            try
            {
                await _contexto.Users.AddAsync(user);
                await _contexto.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(User newUser, int oldUserId)
        {
            try
            {
                User oldUser = await this.Find(oldUserId);
                if (oldUser != null)
                {
                    newUser.Id = oldUser.Id;

                    _contexto.Entry(newUser).State = EntityState.Modified;
                    await _contexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Conta não encontrada!");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<User> Find(int id)
        {
            return await _contexto.Users.Where(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        
        public async Task<User> FindByEmailAndPassword(string email, string password)
        {
            return await _contexto.Users.Where(c => c.Email.Equals(email) && c.Password.Equals(password)).AsNoTracking().FirstOrDefaultAsync();
        }

    }
}
