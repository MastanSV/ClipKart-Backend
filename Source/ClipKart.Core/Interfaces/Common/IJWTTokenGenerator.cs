namespace ClipKart.Core.Interfaces.Common
{
    public interface IJWTTokenGenerator
    {
        string Generate(string userId, string role);
    }
}
