#if NETCOREAPP3_0
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Autofac.Extensions.DependencyInjection.Test
{
    public sealed class ServiceProviderExtensionsTests
    {
        [Fact]
        public void GetAutofacRootReturnsLifetimeScope()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(new ServiceCollection());

            var container = containerBuilder.Build();
            var serviceProvider = container.Resolve<IServiceProvider>();

            Assert.NotNull(serviceProvider.GetAutofacRoot());
        }

        [Fact]
        public void GetAutofacRootServiceProviderNotAutofacServiceProviderThrows()
            => Assert.Throws<InvalidOperationException>(() =>
                new ServiceCollection().BuildServiceProvider().GetAutofacRoot());
    }
}
#endif