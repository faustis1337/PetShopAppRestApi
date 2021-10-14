namespace Faust.PetShopApp.MySecurity.Data
{
    public interface ISecurityContextInitializer
    {
        void Initialize(SecurityContext context);
    }
}