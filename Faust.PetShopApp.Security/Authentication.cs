using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Security
{
    public class Authentication : IAuthentication
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            throw new System.NotImplementedException();
        }

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            throw new System.NotImplementedException();
        }

        public string GenerateToken(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}