# Adding support for ASP.NET Core 3.0

## Problems

1. Returning `IServiceProvider` from `ConfigureServices` delegate is not [allowed](https://github.com/aspnet/AspNetCore/issues/5149).
2. Registering `IServiceProviderFactory` as a service no longer works. We must add it to `HostBuilder` using `UseServiceProviderFactory(new AutofacServiceProviderFactory())`. 
This allows adding the delegate `ConfigureContainer<TContainer>(TContainer container)` to `Startup` class which was possible before by calling `sp.AddAutofac()` when using `ConfigureServices` while building the web-host.
3. Some issues I cannot properly describe because I haven't understood them so far. In particular [this](https://github.com/autofac/Autofac.Extensions.DependencyInjection/issues/36#issuecomment-470778393) and [that](https://github.com/autofac/Autofac.Extensions.DependencyInjection/issues/36#issuecomment-506411656) comment from @tillig

## Necessary changes

1. For problem #1 we will have to update the docs
2. For problem #2 we will also have to update the docs, remove the extension method `AddAutofac()` -> breaking change, add a new extension method on `HostBuilder` that internally creates an instance of `AutofacServiceProviderFactory`
3. For problem #3 we will also have to update the docs most likely and ???  