using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Interface
{
    public interface IMetamaskInterop
    {
        ValueTask<string> EnableEthereumAsync();
        ValueTask<bool> CheckMetamaskAvailability();


    }
}
