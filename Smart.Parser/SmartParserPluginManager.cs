using System.Reflection;

public interface ISmartParserPluginManager
{
    IPluginOptions Options { get; }
    ICollection<IDocumentParser> Plugins { get; }
    void Register(IDocumentParser parser);
    void DiscoverAndRegisterPlugins();
}

public class SmartParserPluginManager : ISmartParserPluginManager
{
    public IPluginOptions Options { get; }
    public ICollection<IDocumentParser> Plugins { get; } = new List<IDocumentParser>();

    public SmartParserPluginManager(IPluginOptions options)
    {
        Options = options;
    }
    public void Register(IDocumentParser parser)
    {
        Plugins.Add(parser);
    }
    public void DiscoverAndRegisterPlugins()
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
                    if (Activator.CreateInstance(type) is IDocumentParser parserInstance)
                    {
                        Register(parserInstance);
                    }
                }
            }
        }
    }

}