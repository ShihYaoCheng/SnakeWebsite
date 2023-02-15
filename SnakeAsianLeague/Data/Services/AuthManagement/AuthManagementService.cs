using SnakeAsianLeague.Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using Blazored.LocalStorage;
using Microsoft.Extensions.Options;
using SnakeAsianLeague.Data.Entity.Config;
using RestSharp;
using System.Net.Http.Headers;
using SnakeAsianLeague.Data.Entity.Authorize;
using System.Net;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;

namespace SnakeAsianLeague.Data.Services.AuthManagement
{
    public class AuthManagementService :  IAuthManagement
    {

        private ExternalServers externalServersConfig;
        private readonly RestClient ServerClient;
        private string OfficialKey;

        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public AuthManagementService(
            IOptions<ExternalServers> myConfiguration, IConfiguration Configuration,
            HttpClient httpClient,ILocalStorageService localStorage)
        {

            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);
            OfficialKey = Configuration.GetSection("Credentials:OfficialKey").Value;
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        /// <summary>
        /// Web token 
        /// </summary>
        public void GetWebAuthorize()
        {
            string URL = $"Web/Authorize?key={OfficialKey}";
            var request = new RestRequest(URL, Method.GET);
            AuthorizeToken token = new AuthorizeToken();
            IRestResponse restResponse = ServerClient.Execute(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                token = JsonSerializer.Deserialize<AuthorizeToken>(restResponse.Content) ?? new AuthorizeToken();
            }
            if (token.AdminRefreshToken != null)
                SetAdminAccessTokenInCookie(token.AdminAccessToken);
            if (token.AdminRefreshToken != null)
                SetAdminRefreshTokenInCookie(token.AdminRefreshToken);
        }

        /// <summary>
        /// Web RefreshToken
        /// </summary>
        public void ExchangeTokensForWeb()
        {
            string URL = $"Web/Tokens";
            var request = new RestRequest(URL, Method.POST);
            request.AddHeader("Authorization", $"Bearer {GetAdminRefreshTokenInCookie()}");
            AuthorizeToken token = new AuthorizeToken();
            IRestResponse restResponse = ServerClient.Execute(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                token = JsonSerializer.Deserialize<AuthorizeToken>(restResponse.Content) ?? new AuthorizeToken();
            }
            if (token.AdminRefreshToken != null)
                SetAdminAccessTokenInCookie(token.AdminAccessToken);
            if (token.AdminRefreshToken != null)
                SetAdminRefreshTokenInCookie(token.AdminRefreshToken);
        }

        public async Task<string> GetAdminAccessTokenInCookie()
        {
            try
            {
                var AccessCookie = AuthManagementCookies.AdminAccessToken;
                if (AccessCookie != null)
                {
                    string AdminAccessToken = AuthManagementCookies.AdminAccessToken;
                    var token = new JwtSecurityToken(jwtEncodedString: AdminAccessToken);
                    string expiry = token.Claims.First(c => c.Type == "exp").Value;
                    int Now = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                    if (int.Parse(expiry) < Now)
                    {
                        //AdminAccessToken 過期 呼叫ExchangeTokensForBackEnd
                        ExchangeTokensForWeb();
                    }
                }
                else
                {
                    var RefreshCookie = AuthManagementCookies.AdminRefreshToken;
                    if (RefreshCookie != null)
                    {
                        ExchangeTokensForWeb();
                    }
                    else
                    {
                        GetWebAuthorize();
                    }
                }
            }
            catch (Exception)
            {
                ExchangeTokensForWeb();
            }
            return AuthManagementCookies.AdminAccessToken;
        }
       
        public async Task<string> GetAdminRefreshTokenInCookie()
        {
            try
            {
                var RefreshCookie = AuthManagementCookies.AdminRefreshToken;
                if (RefreshCookie != null)
                {
                    string AdminAccessToken = AuthManagementCookies.AdminAccessToken;
                    var token = new JwtSecurityToken(jwtEncodedString: AdminAccessToken);
                    string expiry = token.Claims.First(c => c.Type == "exp").Value;
                    int Now = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                    if (int.Parse(expiry) < Now)
                    {
                        ExchangeTokensForWeb();
                    }
                }
                else
                {
                    GetWebAuthorize();
                }
            }
            catch (Exception)
            {
                GetWebAuthorize();
            }
            return AuthManagementCookies.AdminRefreshToken;
        }


        public async void SetAdminAccessTokenInCookie(string accessToken)
        {
            AuthManagementCookies.AdminAccessToken = accessToken;
        }

        public async void SetAdminRefreshTokenInCookie(string refreshToken)
        {
            AuthManagementCookies.AdminRefreshToken = refreshToken;
        }





        /// <summary>
        /// 使用者登入 取得userAccessToken/userRefreshToken
        /// </summary>
        /// <param name="PhoneId"></param>
        /// <param name="Password"></param>
        public async void UserLoginByAccountPassword(string PhoneId, string Password)
        {
            UserLoginByAccountPasswordDto dto = new UserLoginByAccountPasswordDto();
            dto.PhoneId = PhoneId;
            dto.Password = Password;
            dto.IsWebToken = true;


            string URL = "User/Login/AccountPassword";
            RestRequest request = new RestRequest(URL, Method.POST);
            request.AddHeader("Authorization", $"Bearer {GetAdminAccessTokenInCookie()}");
            JsonParameter JP = new JsonParameter("", dto);
            request.AddParameter(JP);

            UserAuthorizeToken token = new UserAuthorizeToken();
            var restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                token = JsonSerializer.Deserialize<UserAuthorizeToken>(restResponse.Content) ?? new UserAuthorizeToken();
            }
            if (token.AccessToken != null)
                SetUserAccessTokenInCookie(token.AccessToken);
            if (token.RefreshToken != null)
                SetUserRefreshTokenInCookie(token.RefreshToken);


        }


        public async void SetUserAccessTokenInCookie(string accessToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(30),
            };
            await _localStorage.SetItemAsync("UserAccessToken", accessToken);
        }

        public async Task<string> GetUserAccessTokenInCookie()
        {
            string savedToken = await _localStorage.GetItemAsync<string>("UserAccessToken");
            return savedToken;
        }

        public async void SetUserRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(30),
            };
            await _localStorage.SetItemAsync("UserRefreshToken", refreshToken);
        }

        public async Task<string> GetUserRefreshTokenInCookie()
        {
            string savedToken = await _localStorage.GetItemAsync<string>("UserRefreshToken");
            return savedToken;
        }
    }
}
