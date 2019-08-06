﻿using System;
using Autofac.Multitenant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Autofac.Integration.AspNetCore.Multitenant.Test
{
    public class AutofacMultitenantWebHostBuilderExtensionsTests
    {
        [Fact]
        public void UseAutofacMultitenantRequestServices_AddsHttpContextAccessor()
        {
            var webHostBuilder = new Mock<IWebHostBuilder>();

            var services = new ServiceCollection();
            webHostBuilder
                .Setup(x => x.ConfigureServices(It.IsAny<Action<IServiceCollection>>()))
                .Callback<Action<IServiceCollection>>(s => s(services));

            var mtc = new MultitenantContainer(Mock.Of<ITenantIdentificationStrategy>(), new ContainerBuilder().Build());
            webHostBuilder.Object.UseAutofacMultitenantRequestServices(() => mtc);

            var serviceProvider = services.BuildServiceProvider();
            var accessor = serviceProvider.GetService<IHttpContextAccessor>();

            Assert.NotNull(accessor);
        }

        [Fact]
        public void UseAutofacMultitenantRequestServices_AddsStartupFilter()
        {
            var webHostBuilder = new Mock<IWebHostBuilder>();

            var services = new ServiceCollection();
            webHostBuilder
                .Setup(x => x.ConfigureServices(It.IsAny<Action<IServiceCollection>>()))
                .Callback<Action<IServiceCollection>>(s => s(services));

            var mtc = new MultitenantContainer(Mock.Of<ITenantIdentificationStrategy>(), new ContainerBuilder().Build());
            webHostBuilder.Object.UseAutofacMultitenantRequestServices(() => mtc);

            var serviceProvider = services.BuildServiceProvider();
            var filter = serviceProvider.GetService<IStartupFilter>();

            Assert.IsType<MultitenantRequestServicesStartupFilter>(filter);
        }

        [Fact]
        public void UseAutofacMultitenantRequestServices_NullBuilder()
        {
            var mtc = new MultitenantContainer(Mock.Of<ITenantIdentificationStrategy>(), new ContainerBuilder().Build());
            Assert.Throws<ArgumentNullException>(() => AutofacMultitenantWebHostBuilderExtensions.UseAutofacMultitenantRequestServices(null, () => mtc));
        }

        [Fact]
        public void UseAutofacMultitenantRequestServices_NullContainerAccessor()
        {
            var builder = Mock.Of<IWebHostBuilder>();
            Assert.Throws<ArgumentNullException>(() => AutofacMultitenantWebHostBuilderExtensions.UseAutofacMultitenantRequestServices(builder, null));
        }
    }
}
