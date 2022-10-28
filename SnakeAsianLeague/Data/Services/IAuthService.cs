using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.SnakeServer;

namespace SnakeAsianLeague.Data.Services
{
    public interface IAuthService
    {
        Task<SnakeAccount> AuthLogin(LoginRequest loginRequest , bool IsAutoLogin);
        Task AuthLogout();
        Task<SnakeAccount> AuthLoginByUserId(string userId);

        LoginRequest DecodeLoginRequest(string EncodedString);
        Task<ServerResponce> PhoneSendVerifyCode(string CountryCode, string PhoneNumber);
        Task<ServerResponce> PhoneRegister(string CountryCode, string PhoneNumber, PhoneMemberRegisterDTO phoneMemberRegisterDTO, string UserName);

        Task<ServerResponce> UserNameModify(uint userId, string name);

    }
}
