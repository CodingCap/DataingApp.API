using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataingApp.API.CQRS.Queries;
using DataingApp.API.Helpers;
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
         
        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<PagedList<User>> GetUsersAsync(GetUsersQuery userParams)
        {
            var users = _dataContext.Users
                .Include(u => u.Photos)
                .OrderBy(u => u.LastActive)
                .AsQueryable();

            users = users.Where(u => u.ID != userParams.UserID);
            users = users.Where(u => u.Gender == userParams.Gender);

            if (userParams.MinAge != 18 || userParams.MaxAge != 99)
            {
                var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

                users = users.Where(u => u.DathOfBirth >= minDob && u.DathOfBirth <= maxDob);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.Created);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _dataContext.Users
                .Include(u => u.Photos)
                .FirstOrDefaultAsync(p => p.ID == id);

            return user;
        }

        public async Task<Photo> GetPhotoAsync(int id)
        {
            return await _dataContext.Photos.FirstOrDefaultAsync(p => p.PhotoId == id);
        }

        public async Task<Photo> GetainPhotoForUser(int userId)
        {
            return await _dataContext.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }
    }
}
