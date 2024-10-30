using System.Reflection;

public interface ISmartParserPluginManager
{
    IPluginOptions Options { get; }
    ICollection<Type> PluginTypes { get; }
    void DiscoverPlugins();
    ICollection<IDocumentParser> InstantinatePlugins();
}

public class SmartParserPluginManager : ISmartParserPluginManager
{
    public IPluginOptions Options { get; }
    public ICollection<Type> PluginTypes { get; } = new List<Type>();

    public SmartParserPluginManager(IPluginOptions options)
    {
        Options = options;
    }

    public void DiscoverPlugins()
    {
        string pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");

        if (!Directory.Exists(pluginPath))
        {
            Console.WriteLine($"Plugin directory {pluginPath} does not exist.");
            return;
        }

        foreach (var dll in Directory.GetFiles(pluginPath, "*.dll", SearchOption.AllDirectories))
        {
            var assembly = Assembly.LoadFrom(dll);
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(IDocumentParser).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    PluginTypes.Add(type);
                }
            }
        }
    }

    public ICollection<IDocumentParser> InstantinatePlugins()
    {
        var plugins = new List<IDocumentParser>();
        foreach (var pluginType in PluginTypes)
        {
            var plugin = (IDocumentParser)Activator.CreateInstance(pluginType);
            plugins.Add(plugin);
        }

        return plugins;
    }
}