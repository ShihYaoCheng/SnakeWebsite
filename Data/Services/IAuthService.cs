using SnakeAsianLeague.Data.Entity;

namespace SnakeAsianLeague.Data.Services
{
    public interface IAuthService
    {
        Task<SnakeAccount> AuthLogin(LoginRequest loginRequest);
        Task AuthLogout();
        Task<SnakeAccount> AuthLoginByUserId(string userId);

        LoginRequest DecodeLoginRequest(string EncodedString);
    }
}
