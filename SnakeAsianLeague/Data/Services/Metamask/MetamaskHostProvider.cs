using SnakeAsianLeague.Data.Services.Interface;
using System;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Metamask
{
    public class MetamaskHostProvider : IEthereumHostProvider
    {
        private readonly IMetamaskInterop _metamaskInterop;
        public static MetamaskHostProvider Current { get; private set; }

        public bool Available { get; private set; }
        public string SelectedAccount { get; private set; }
        public bool Enabled { get; private set; }


        private MetamaskInterceptor _metamaskInterceptor;


        public event Func<string, Task> SelectedAccountChanged;
        public event Func<bool, Task> AvailabilityChanged;

        public MetamaskHostProvider(IMetamaskInterop metamaskInterop)
        {
            _metamaskInterop = metamaskInterop;
            _metamaskInterceptor = new MetamaskInterceptor(_metamaskInterop, this);
            Current = this;
        }

        public async Task<bool> CheckProviderAvailabilityAsync()
        {
            var result = await _metamaskInterop.CheckMetamaskAvailability();
            await ChangeMetamaskAvailableAsync(result);
            return result;
        }

        public async Task<string> EnableProviderAsync()
        {
            var selectedAccount = await _metamaskInterop.EnableEthereumAsync();
            Enabled = !string.IsNullOrEmpty(selectedAccount);

            if (Enabled)
            {
                SelectedAccount = selectedAccount;
                if (SelectedAccountChanged != null)
                {
                    await SelectedAccountChanged.Invoke(selectedAccount);
                }
                return selectedAccount;
            }

            return null;
        }


        public async Task ChangeMetamaskAvailableAsync(bool available)
        {
            Available = available;
            if (AvailabilityChanged != null)
            {
                await AvailabilityChanged.Invoke(available);
            }
        }

        public async Task<bool> MetamaskAddTokenAsync()
        {
            var result = await _metamaskInterop.MetamaskAddToken();
            return result;
        }
    }
}
