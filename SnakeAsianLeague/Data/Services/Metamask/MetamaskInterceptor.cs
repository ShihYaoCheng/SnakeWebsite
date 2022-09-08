using Nethereum.JsonRpc.Client;
using SnakeAsianLeague.Data.Services.Interface;
using System;
using System.Threading.Tasks;

namespace SnakeAsianLeague.Data.Services.Metamask
{
    public class MetamaskInterceptor : RequestInterceptor
    {
        private readonly IMetamaskInterop _metamaskInterop;
        private readonly MetamaskHostProvider _metamaskHostProvider;

        public MetamaskInterceptor(IMetamaskInterop metamaskInterop, MetamaskHostProvider metamaskHostProvider)
        {
            _metamaskInterop = metamaskInterop;
            _metamaskHostProvider = metamaskHostProvider;
        }

    }
}
