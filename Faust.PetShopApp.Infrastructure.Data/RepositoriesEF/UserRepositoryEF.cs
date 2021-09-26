using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Infrastructure.Entities;

namespace Faust.PetShopApp.Infrastructure.RepositoriesEF
{
    public class UserRepositoryEF:IUserRepository
    {
        private readonly PetAppContext _ctx;

        public UserRepositoryEF(PetAppContext ctx)
        {
            _ctx = ctx;
        }
        
        public IEnumerable<User> ReadUsers()
        {
            return _ctx.Users.Select(user => new User{Id = user.Id,IsAdmin = user.IsAdmin,PasswordHash = user.PasswordHash,PasswordSalt = user.PasswordSalt,Username = user.Username}).ToList();
        }

        public User Read(int id)
        {
            return _ctx.Users.Select(user => new User{Id = user.Id,IsAdmin = user.IsAdmin,PasswordHash = user.PasswordHash,PasswordSalt = user.PasswordSalt,Username = user.Username}).FirstOrDefault();
        }

        public User Create(User user)
        {
            var userEntity = new UserEntity { Id = user.Id,IsAdmin = user.IsAdmin,PasswordHash = user.PasswordHash,PasswordSalt = user.PasswordSalt,Username = user.Username};
            var addedUser = _ctx.Users.Add(userEntity).Entity;
            _ctx.SaveChanges();
            return new User
            {
                Id = addedUser.Id, IsAdmin = addedUser.IsAdmin, PasswordHash = addedUser.PasswordHash,
                PasswordSalt = addedUser.PasswordSalt, Username = addedUser.Username
            };
        }

        public User Delete(int id)
        {
            var entity = _ctx.Users.FirstOrDefault(user => user.Id == id);
            var deletedUserEntity = _ctx.Users.Remove(entity).Entity;
            _ctx.SaveChanges();
            return new User
            {
                Id = deletedUserEntity.Id, IsAdmin = deletedUserEntity.IsAdmin, PasswordHash = deletedUserEntity.PasswordHash,
                PasswordSalt = deletedUserEntity.PasswordSalt, Username = deletedUserEntity.Username
            };
        }

        public User Update(User updateUser)
        {
            var updatedEntity = _ctx.Update(new UserEntity()
            {
                Id = updateUser.Id,
                Username = updateUser.Username,
                IsAdmin = updateUser.IsAdmin,
                PasswordHash = updateUser.PasswordHash,
                PasswordSalt = updateUser.PasswordSalt

            }).Entity;
            _ctx.SaveChanges();
            return new User()
            {
                Id = updatedEntity.Id,
                Username = updatedEntity.Username,
                IsAdmin = updatedEntity.IsAdmin,
                PasswordHash = updatedEntity.PasswordHash,
                PasswordSalt = updatedEntity.PasswordSalt
            };
        }
    }
}