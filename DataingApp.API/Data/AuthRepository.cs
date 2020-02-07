using System.Text;
using System.Threading.Tasks;
using DataingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DataingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;

        public AuthRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<User> Register(User user, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PaswordSalt = passwordSalt;

            await _dataContext.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string passwword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwword));
        }

        public async Task<User> Login(string userName, string passwword)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(passwword, user.PasswordHash, user.PaswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string passwword, byte[] userPasswordHash, byte[] userPaswordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(userPaswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwword));

            for(int i =0; i < computedHash.Length; i++)
                if (computedHash[i] != userPasswordHash[i])
                    return false;

            return true;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _dataContext.Users.AnyAsync(x => x.UserName == userName);
        }
    }
}
