#if NETCOREAPP3_0

using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable 1591
namespace Autofac.Extensions.DependencyInjection
{
    /// <summary>
    /// TODO .
    /// </summary>
    public class AutofacRootScopeServiceProviderFactoryActions
    {
        private readonly List<Action<ContainerBuilder>> _configureActions = new List<Action<ContainerBuilder>>();

        public void Add(Action<ContainerBuilder> configureAction)
        {
            if (configureAction == null) throw new ArgumentNullException(nameof(configureAction));

            _configureActions.Add(configureAction);
        }

        public IReadOnlyList<Action<ContainerBuilder>> ConfigureActions => _configureActions;
    }
}

#endif