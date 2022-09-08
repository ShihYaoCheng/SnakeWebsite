using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using SnakeAsianLeague.Data.Entity;
using SnakeAsianLeague.Data.Entity.Config;
using SnakeAsianLeague.Data.Entity.SnakeServer;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services
{
    public class LoginService 
    {
        private readonly RestClient ServerClient;
        private ExternalServers externalServersConfig;

        
        public LoginService(IOptions<ExternalServers> myConfiguration)
        {
            externalServersConfig = myConfiguration.Value;
            ServerClient = new RestClient(externalServersConfig.UserServer);

        }

        public async Task<SnakeAccount> Login(LoginRequest loginRequest)
        {
            //Console.WriteLine("Login: " + JsonSerializer.Serialize(loginRequest));
            //Console.WriteLine("UserServer: " + externalServersConfig.UserServer);

            SnakeAccount response = await tryLogin(loginRequest);

            if (response.IsLogin)
            {
                //Console.WriteLine("Login sucess: " + JsonSerializer.Serialize(response));
                return response;
            }
            else {
                return new SnakeAccount();
            }
        }

        private async Task<SnakeAccount> tryLogin(LoginRequest loginRequest)
        {
            var LoginRestRequest = new RestRequest($"User/PhoneID?PhoneID={loginRequest.phone}&PW={loginRequest.password}&&DeviceID=WEB&IP=NOIP");
            LoginRestRequest.AddHeader("Authorization", Authenticate());
            
            IRestResponse restResponse = await ServerClient.ExecuteGetAsync(LoginRestRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK) 
            {
                //Console.WriteLine($" {restResponse.StatusCode},{restResponse.Content}");
                SnakeLoginResponce loginResp = JsonSerializer.Deserialize<SnakeLoginResponce>(restResponse.Content);

                return new SnakeAccount() { userID = loginResp.userID, name = loginResp.name , phone = loginRequest .phone, walletAddress = loginResp.walletAddress , nftCurrency1  =loginResp.nftCurrency1};
            }
            return new SnakeAccount();
        }

        private string Authenticate()
        {
            string auth = "Unity:Yx2fy5tFfDHAfU7Az";
            auth = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            return auth;
        }
    }
}
