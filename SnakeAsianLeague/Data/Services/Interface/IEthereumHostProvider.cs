using System;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Interface
{
    public interface IEthereumHostProvider
    {

        bool Available { get; }
        string SelectedAccount { get; }
        bool Enabled { get; }

        event Func<string, Task> SelectedAccountChanged;

        event Func<bool, Task> AvailabilityChanged;

        Task<bool> CheckProviderAvailabilityAsync();

        Task<string> EnableProviderAsync();

        Task<bool> MetamaskAddTokenAsync();


    }
}
