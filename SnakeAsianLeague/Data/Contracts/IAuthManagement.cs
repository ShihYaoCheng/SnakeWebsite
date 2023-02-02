namespace SnakeAsianLeague.Data.Contracts
{
    public interface IAuthManagement
    {
        /// <summary>
        /// api 取得一組新的AccessToke/RefreshToken
        /// </summary>
        void GetWebAuthorize();


        /// <summary>
        /// api RefreshToken取得一組新的AccessToke/RefreshToken
        /// </summary>
        void ExchangeTokensForWeb();


        /// <summary>
        /// 設定AccessToke
        /// </summary>
        /// <param name="accessToken"></param>
        void SetAdminAccessTokenInCookie(string accessToken);

        /// <summary>
        /// 取得AccessToke
        /// </summary>
        /// <returns></returns>
        Task<string> GetAdminAccessTokenInCookie();

        /// <summary>
        /// 設定RefreshToken
        /// </summary>
        /// <param name="refreshToken"></param>
        void SetAdminRefreshTokenInCookie(string refreshToken);

        /// <summary>
        /// 取得RefreshToken
        /// </summary>
        /// <returns></returns>
        Task<string> GetAdminRefreshTokenInCookie();







        void UserLoginByAccountPassword(string PhoneId, string Password);



        void SetUserAccessTokenInCookie(string accessToken);

        Task<string> GetUserAccessTokenInCookie();

        void SetUserRefreshTokenInCookie(string refreshToken);

        Task<string> GetUserRefreshTokenInCookie();




    }
}
