#if NETCOREAPP3_0
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable 1591
namespace Autofac.Extensions.DependencyInjection
{
    /// <summary>
    /// TODO.
    /// </summary>
    public class AutofacRootScopeServiceProviderFactory : IServiceProviderFactory<AutofacRootScopeServiceProviderFactoryActions>
    {
        private readonly Action<ContainerBuilder> _containerConfigurationAction;
        private readonly ILifetimeScope _rootScope;

        public AutofacRootScopeServiceProviderFactory(Func<ILifetimeScope> getRootScopeFunc, Action<ContainerBuilder> containerConfigurationAction = null)
        {
            if (getRootScopeFunc == null) throw new ArgumentNullException(nameof(getRootScopeFunc));

            _rootScope = getRootScopeFunc();
            _containerConfigurationAction = containerConfigurationAction ?? (builder => { });
        }

        public AutofacRootScopeServiceProviderFactoryActions CreateBuilder(IServiceCollection services)
        {
            var actions = new AutofacRootScopeServiceProviderFactoryActions();

            actions.Add(builder => builder.Populate(services));
            actions.Add(builder => _containerConfigurationAction(builder));

            return actions;
        }

        public IServiceProvider CreateServiceProvider(AutofacRootScopeServiceProviderFactoryActions containerBuilderActions)
        {
            if (containerBuilderActions == null) throw new ArgumentNullException(nameof(containerBuilderActions));

            var scope = _rootScope.BeginLifetimeScope(scopeBuilder =>
            {
                foreach (var action in containerBuilderActions.ConfigureActions)
                {
                    action(scopeBuilder);
                }
            });

            return new AutofacServiceProvider(scope);
        }
    }
}
#endif