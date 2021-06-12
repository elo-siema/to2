namespace TheShow.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(int size = 32);
    }
}