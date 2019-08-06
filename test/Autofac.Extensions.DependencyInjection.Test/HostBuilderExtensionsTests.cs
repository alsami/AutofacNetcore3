#if NETCOREAPP3_0
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Autofac.Extensions.DependencyInjection.Test
{
    public sealed class HostBuilderExtensionsTests
    {
        [Fact]
        public void UseAutofacAutofacServiceProviderResolveable()
        {
            var host = Host.CreateDefaultBuilder(null)
                .UseAutofac()
                .Build();

            host.Services.GetRequiredService<ILifetimeScope>();
        }
    }
}
#endif