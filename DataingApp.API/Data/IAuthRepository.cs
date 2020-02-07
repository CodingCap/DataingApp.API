using System.Threading.Tasks;
using DataingApp.API.Models;

namespace DataingApp.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string userName, string passord);

        Task<bool> UserExists(string userName);
    }
}
