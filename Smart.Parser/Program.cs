using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddSingleton<IArgsParser, ArgsParser>((context) => ArgsParser.Instanate(args));
services.AddSingleton<IPluginOptions, PluginOptions>((context) =>
{
    var arguments = context.GetRequiredService<IArgsParser>();
    return (PluginOptions)arguments.CreatePluginOptions();
});
services.AddSingleton<ISmartParserPluginManager, SmartParserPluginManager>((context) =>
{
    var manager = new SmartParserPluginManager(context.GetRequiredService<IPluginOptions>());
    manager.DiscoverAndRegisterPlugins();
    return manager;
});
services.AddSingleton<ISmartParser, SmartParser>();


App.Provider = services.BuildServiceProvider();

var parser = App.Provider.GetRequiredService<ISmartParser>();

await parser.Parse();


public static class App
{
    public static ServiceProvider Provider { get; set; }
}