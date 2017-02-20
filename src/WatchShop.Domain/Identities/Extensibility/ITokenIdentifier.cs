namespace WatchShop.Domain.Identities.Extensibility
{
    public interface ITokenIdentifier
    {
        string GenerateToken(string email, string password);

        bool ValidateToken(string token);
    }
}