namespace Faust.PetShopApp.Infrastructure.Entities
{
    public class UserEntity
    {
        public long Id { get; set;}
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
    }
}