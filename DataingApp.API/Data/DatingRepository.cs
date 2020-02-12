using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DataingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {

        private readonly DataContext _dataContext;
        public DatingRepository(DataContext context)
        {
            this._dataContext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Delete<T>(T enitity) where T : class
        {
            _dataContext.Remove(enitity);
        }

        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dataContext.Users
                .Include(u => u.Photos)
                .ToListAsync();

            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dataContext.Users
                .Include(u => u.Photos)
                .FirstOrDefaultAsync(p => p.ID == id);

            return user;
        }
    }
}
