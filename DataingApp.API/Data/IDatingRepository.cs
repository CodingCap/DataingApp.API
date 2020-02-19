using System.Collections.Generic;
using System.Threading.Tasks;
using DataingApp.API.Models;

namespace DataingApp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T enitity) where T : class;

        Task<bool> SaveAllAsync();

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<Photo> GetPhotoAsync(int id);
    }
}
