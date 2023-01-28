public interface IMvcApplication
{
    void Configure(IList<Route> routeTable);

    void ConfigureServices(IServiceCollection serviceCollection);
}