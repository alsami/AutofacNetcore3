using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AutofacNetcore3.Rootscope
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureContainer(AutofacRootScopeServiceProviderFactoryActions actions)
        {
            actions.Add(builder => builder.RegisterType<ServiceOne>().As<IServiceOne>().InstancePerLifetimeScope());
            actions.Add(builder => builder.RegisterType<ServiceTwo>().As<IServiceTwo>().InstancePerLifetimeScope());
        }

        public static ILifetimeScope BuildRootContainer() => new ContainerBuilder().Build();
    }
}