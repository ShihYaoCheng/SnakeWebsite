using SnakeAsianLeague.Data.Services.Interface;
using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace SnakeAsianLeague.Data.Services.Metamask
{
    public class MetamaskBlazorInterop : IMetamaskInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public MetamaskBlazorInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async ValueTask<string> EnableEthereumAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("NethereumMetamaskInterop.EnableEthereum");
        }

        public async ValueTask<bool> CheckMetamaskAvailability()
        {
            return await _jsRuntime.InvokeAsync<bool>("NethereumMetamaskInterop.IsMetamaskAvailable");
        }

        public async ValueTask<bool> MetamaskAddToken()
        {
            return await _jsRuntime.InvokeAsync<bool>("NethereumMetamaskInterop.AddToken");
        }
    }
}
