using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Multitenant;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AutofacNetcore2
{
    public class Startup
    {
        public static MultitenantContainer ApplicationContainer;

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(services);

            var container = containerBuilder.Build();

            var mtc = new MultitenantContainer(
                new TenantIdentitificationStrategy(container.Resolve<IHttpContextAccessor>()), container);

            mtc.ConfigureTenant(TenantIdentitificationStrategy.TenantIds[0], builder => builder
                .RegisterType<TenantOneService>().As<ITenantService>());

            mtc.ConfigureTenant(TenantIdentitificationStrategy.TenantIds[1], builder => builder
                .RegisterType<TenantTwoService>().As<ITenantService>());

            Startup.ApplicationContainer = mtc;

            return new AutofacServiceProvider(mtc);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
