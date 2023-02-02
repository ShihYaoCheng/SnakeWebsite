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
            string savedToken = await _localStorage.GetItemAsync<string>("AdminAccessToken");
            return savedToken;
        }
       
        public async Task<string> GetAdminRefreshTokenInCookie()
        {
            string savedToken = await _localStorage.GetItemAsync<string>("AdminRefreshToken");
            return savedToken;
        }


        public async void SetAdminAccessTokenInCookie(string accessToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };
            //Response.Cookies.Append("AdminAccessToken", accessToken, cookieOptions);
            await  _localStorage.SetItemAsync("AdminAccessToken", accessToken);
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
        }

        public async void SetAdminRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(30),
            };
            //Response.Cookies.Append("AdminRefreshToken", refreshToken, cookieOptions);

            await _localStorage.SetItemAsync("AdminRefreshToken", refreshToken);
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", refreshToken);
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
            //Response.Cookies.Append("AdminRefreshToken", refreshToken, cookieOptions);

            await _localStorage.SetItemAsync("UserAccessToken", accessToken);
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", refreshToken);
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
            //Response.Cookies.Append("AdminRefreshToken", refreshToken, cookieOptions);

            await _localStorage.SetItemAsync("UserRefreshToken", refreshToken);
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", refreshToken);
        }

        public async Task<string> GetUserRefreshTokenInCookie()
        {
            string savedToken = await _localStorage.GetItemAsync<string>("UserRefreshToken");
            return savedToken;
        }
    }
}
