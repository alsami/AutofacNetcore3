// This software is part of the Autofac IoC container
// Copyright © 2017 Autofac Contributors
// https://autofac.org
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

#if NETCOREAPP3_0
using System;
using Microsoft.Extensions.Hosting;

namespace Autofac.Extensions.DependencyInjection
{
    /// <summary>
    /// TODO.
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="hostBuilder">TODO s.</param>
        /// <param name="configureAction">TODO sss.</param>
        public static IHostBuilder UseAutofac(this IHostBuilder hostBuilder, Action<ContainerBuilder> configureAction = null) =>
            hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory(configureAction));
    }
}
#endif