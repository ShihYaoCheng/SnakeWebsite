using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace SnakeAsianLeague.Areas.Identity
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;


        public CustomAuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }


        /// <summary>
        /// 抽象類別
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {

                JWTHelper jWT = new JWTHelper();
                var savedToken = await _localStorage.GetItemAsync<string>("authToken");
                

                if (string.IsNullOrWhiteSpace(savedToken))
                {
                    return new AuthenticationState(new ClaimsPrincipal());
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);



                var aa = jWT.ParseClaimsFromJwt(savedToken);

                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(jWT.ParseClaimsFromJwt(savedToken), "jwt")));
            }
            catch (Exception )
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }
        }

        /// <summary>
        /// 登入紀錄authState
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public void MarkUserAsAuthenticated(string name)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, name) }, "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        /// <summary>
        /// 登出刪除authState
        /// </summary>
        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

     
    }
}
