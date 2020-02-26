using System.Collections.Generic;
using System.Threading.Tasks;
using DataingApp.API.CQRS.Queries;
using DataingApp.API.Helpers;
using DataingApp.API.Models;

namespace DataingApp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T enitity) where T : class;

        Task<bool> SaveAllAsync();

        Task<PagedList<User>> GetUsersAsync(GetUsersQuery userParams);

        Task<User> GetUserAsync(int id);

        Task<Photo> GetPhotoAsync(int id);

        Task<Photo> GetainPhotoForUser(int userId);
    }
}
