using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Areas.Identity;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SnakeAsianLeague.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        public AuthService(IOptions<ExternalServers> myConfiguration ,
                            HttpClient httpClient,
                            AuthenticationStateProvider authenticationStateProvider,
                            ILocalStorageService localStorage)
        {
            externalServersConfig = myConfiguration.Value;            
            ServerClient = new RestClient(externalServersConfig.UserServer);
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SnakeAccount"></param>
        /// <returns></returns>
        public async Task<SnakeAccount> AuthLogin(LoginRequest loginRequest)
        {
            SnakeAccount response = await tryLogin(loginRequest);
            if (response.IsLogin)
            {
                string token = await GetAuthenticationToken(loginRequest);
                //string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiIxMTQwNyIsIk5hbWUiOiLmv5Xmv5XnjYXlrZDkuLgiLCJQaG9uZSI6Iis4ODY5NzU1MTE3MzMiLCJXYWxsZXRBZGRyZXNzIjoiIiwiZXhwIjoxNjQ4MDI0NjE5LCJpc3MiOiJjcWlBdXRoRGVtbyJ9.fijum60o3s-G1CEt4fztdlXfpviVVG9h7DqEyG9L9B4";
                await _localStorage.SetItemAsync("authToken", token);
                ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(response.name);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return response;
            }
            else
            {
                return new SnakeAccount();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task AuthLogout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        private async Task<SnakeAccount> tryLogin(LoginRequest loginRequest)
        {
            var LoginRestRequest = new RestRequest($"User/PhoneID?PhoneID={loginRequest.phone}&PW={loginRequest.password}&&DeviceID=WEB&IP=NOIP");
            LoginRestRequest.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(LoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                //Console.WriteLine($" {restResponse.StatusCode},{restResponse.Content}");
                SnakeLoginResponce loginResp = JsonSerializer.Deserialize<SnakeLoginResponce>(restResponse.Content);

                return new SnakeAccount() { userID = loginResp.userID, name = loginResp.name, phone = loginRequest.phone, walletAddress = loginResp.walletAddress };
            }
            return new SnakeAccount();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        private async Task<string> GetAuthenticationToken(LoginRequest loginRequest)
        {
            var LoginRestRequest = new RestRequest($"BackEnd/Login?PhoneID={loginRequest.phone}&PW={loginRequest.password}");
            LoginRestRequest.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(LoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                string token = JsonSerializer.Deserialize<string>(restResponse.Content)??"";
                return token;
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string Authenticate()
        {
            string auth = "Unity:Yx2fy5tFfDHAfU7Az";
            auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            return auth;
        }
    }
}
