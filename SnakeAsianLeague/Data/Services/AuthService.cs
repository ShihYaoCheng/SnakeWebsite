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
        public async Task<SnakeAccount> AuthLogin(LoginRequest loginRequest , bool IsAutoLogin)
        {
            //國碼 手機 處理
            if (loginRequest.countryCode == null)
            {
                loginRequest.countryCode = "%2B886";
            }
            else
            {
                loginRequest.countryCode = loginRequest.countryCode.Replace("+", "%2B");
            }
            loginRequest.phone = loginRequest.phone.TrimStart('0');


            SnakeAccount response = await tryLogin(loginRequest);
            if (response.IsLogin)
            {
                if (IsAutoLogin)
                {
                    string token = await GetAuthenticationToken(loginRequest);
                    //string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiIxMTQwNyIsIk5hbWUiOiLmv5Xmv5XnjYXlrZDkuLgiLCJQaG9uZSI6Iis4ODY5NzU1MTE3MzMiLCJXYWxsZXRBZGRyZXNzIjoiIiwiZXhwIjoxNjQ4MDI0NjE5LCJpc3MiOiJjcWlBdXRoRGVtbyJ9.fijum60o3s-G1CEt4fztdlXfpviVVG9h7DqEyG9L9B4";
                    await _localStorage.SetItemAsync("authToken", token);

                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                }     
                ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(response.name);
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
            var LoginRestRequest = new RestRequest($"User/PhoneID?PhoneID={loginRequest.countryCode+loginRequest.phone}&PW={loginRequest.password}&&DeviceID=WEB&IP=NOIP");
            LoginRestRequest.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(LoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                //Console.WriteLine($" {restResponse.StatusCode},{restResponse.Content}");
                SnakeLoginResponce loginResp = JsonSerializer.Deserialize<SnakeLoginResponce>(restResponse.Content);

                return new SnakeAccount() { userID = loginResp.userID, name = loginResp.name, phone = loginRequest.phone, walletAddress = loginResp.walletAddress , nftCurrency1 = loginResp.nftCurrency1};
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

        public async Task<SnakeAccount> AuthLoginByUserId(string userId)
        {
            var request = new RestRequest($"User", Method.GET);
            request.AddQueryParameter("UserID", userId);
            request.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                SnakeLoginResponce loginResp = JsonSerializer.Deserialize<SnakeLoginResponce>(restResponse.Content);

                return new SnakeAccount() { userID = loginResp.userID, name = loginResp.name, phone = loginResp.phoneID, walletAddress = loginResp.walletAddress, nftCurrency1 = loginResp.nftCurrency1 };
            }
            return new SnakeAccount();


        }

        public LoginRequest DecodeLoginRequest(string EncodedString)
        {
            
            try {
                var base64EncodedBytes = System.Convert.FromBase64String(EncodedString);
                string decodeString = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                LoginRequest loginReq = JsonSerializer.Deserialize<LoginRequest>(decodeString);

                return loginReq;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public async Task<ServerResponce> PhoneSendVerifyCode(string CountryCode, string PhoneNumber)
        {
            ServerResponce serverResponce = new ServerResponce();

            try {
                PhoneMemberSendSmsDTO dto = new PhoneMemberSendSmsDTO();
                dto.PhoneNumber = PhoneNumberCombination( CountryCode , PhoneNumber);
                dto.SmsType = SmsType.CreateByPhone;
                string jsonData = JsonSerializer.Serialize(dto);



                var request = new RestRequest($"User/SMS/VerifyCode", Method.POST);


                request.AddJsonBody(jsonData);
                request.AddHeader("Authorization", Authenticate());

                IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
                
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    serverResponce.Success = true;
                }
                else
                {
                    serverResponce.Success = false;
                    serverResponce.Content = restResponse.StatusCode.ToString();

                }
            }
            catch(Exception e) 
            {
                serverResponce.Success = false;
                serverResponce.Content = e.Message;

            }
            return serverResponce;



        }

        public async Task<ServerResponce> PhoneRegister(string CountryCode, string PhoneNumber,PhoneMemberRegisterDTO phoneMemberRegisterDTO)
        {
            ServerResponce serverResponce = new ServerResponce();

            try
            {
                phoneMemberRegisterDTO.PhoneNumber = PhoneNumberCombination(CountryCode, PhoneNumber);
                phoneMemberRegisterDTO.SmsType = SmsType.CreateByPhone;
                phoneMemberRegisterDTO.DeviceID = phoneMemberRegisterDTO.PhoneNumber;
                string jsonData = JsonSerializer.Serialize(phoneMemberRegisterDTO);


                var request = new RestRequest($"User/SMS/Register", Method.POST);


                request.AddJsonBody(jsonData);
                request.AddHeader("Authorization", Authenticate());

                IRestResponse restResponse = await ServerClient.ExecuteAsync(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    serverResponce.Success = true;
                    SnakeAccount account = JsonSerializer.Deserialize<SnakeAccount>(restResponse.Content);
                    
                }
                else
                {
                    serverResponce.Success = false;
                    serverResponce.Content = restResponse.Content;

                }
            }
            catch (Exception e)
            {
                serverResponce.Success = false;
                serverResponce.Content = e.Message;

            }
            return serverResponce;
        }

        public string PhoneNumberCombination (string CountryCode, string PhoneNumber)
        {
            string str = "";
            if (PhoneNumber.Substring(0, 1) == "0")
            {
                PhoneNumber = PhoneNumber.Substring(1);
            }
            if (CountryCode.Substring(0, 1) != "+")
            {
                CountryCode = "+" + CountryCode;
            }

            str = CountryCode + PhoneNumber;
            return str;

        }

        public async Task<ServerResponce> UserNameModify(uint userId,string name)
        {
            ServerResponce serverResponce = new ServerResponce();
            var request = new RestRequest($"User/Name", Method.GET);
            request.AddQueryParameter("UserID", userId.ToString());
            request.AddQueryParameter("Name", name);
            request.AddHeader("Authorization", Authenticate());

            IRestResponse restResponse = await ServerClient.ExecuteAsync(request);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                serverResponce.Success = true;
            }
            else
            {
                serverResponce.Success = false;
                serverResponce.Content = restResponse.Content;

            }

            return serverResponce;
        }
    }
}
