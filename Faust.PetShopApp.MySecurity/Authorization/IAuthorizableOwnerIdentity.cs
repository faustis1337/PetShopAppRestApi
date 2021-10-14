namespace Faust.PetShopApp.MySecurity.Authorization
{
    public interface IAuthorizableOwnerIdentity
    {
        long getAuthorizedOwnerId();

        string getAuthorizedOwnerName();
    }
}