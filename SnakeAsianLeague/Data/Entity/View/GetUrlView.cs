using Microsoft.Extensions.Options;
using SnakeAsianLeague.Data.Entity.Config;

namespace SnakeAsianLeague.Data.Entity.View
{
    public class GetUrlView
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        string host { get; set; }
        public GetUrlView(IOptions<ExternalServers> myConfiguration, IHttpContextAccessor httpContextAccessor)
        {

            _httpContextAccessor = httpContextAccessor;
             host = _httpContextAccessor.HttpContext.Request.Host.Value;


        }

        public async Task<string> GetUrl(){            
            return host;
        }
    }
}
