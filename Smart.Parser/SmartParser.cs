using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Parser
{
    public interface ISmartParser
    {
        Task<string> Parse();
    }
    public class SmartParser : ISmartParser
    {
        ISmartParserPluginManager manager;
        public SmartParser(ISmartParserPluginManager pluginManager)
        {
            manager = pluginManager;
        }
        public async Task<string> Parse()
        {
            manager.Options.CollectFiles();
            var tasks = new List<Task>();
            var semaphore = new SemaphoreSlim(10);

            foreach (var file in manager.Options.InputFiles)
            {
                var plugins = manager.InstantinatePlugins();
                foreach (var plugin in plugins)
                {
                    await semaphore.WaitAsync();
                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            await plugin.Parse(file);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));
                }
            }

            await Task.WhenAll(tasks);
            return null;
        }
    }
}
