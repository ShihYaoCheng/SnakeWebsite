namespace SnakeAsianLeague.Data.Entity.Authorize
{
    public class AuthorizeToken
    {
        public string AdminRefreshToken { get; set; }

        public string AdminAccessToken { get; set; }
    }


    public class UserAuthorizeToken
    {
        public string RefreshToken { get; set; }

        public string AccessToken { get; set; }
    }



    public class UserLoginByAccountPasswordDto
    {
        public string PhoneId { get; set; }
        public string Password { get; set; }
        public bool IsWebToken { get; set; }
    }
 }
