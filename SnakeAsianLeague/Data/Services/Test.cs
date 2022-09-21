
using Microsoft.JSInterop;

namespace SnakeAsianLeague.Data.Services
{
    public class Day22SampleService
    {
        [JSInvokable]
        public int Sum(int a, int b) => a + b;
    }
}
