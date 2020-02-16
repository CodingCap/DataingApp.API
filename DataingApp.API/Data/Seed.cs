using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataingApp.API.Models;
using Newtonsoft.Json;

namespace DataingApp.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeed.json");

                var users = JsonConvert.DeserializeObject<List<User>>(userData);


                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;

                    CreatePasswordHash("1982", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PaswordSalt = passwordSalt;

                    user.UserName = user.UserName.ToLower();

                    context.Add(user);
                }

                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string passwword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwword));
        }
    }
}
