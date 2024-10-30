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
            foreach (var file in manager.Options.InputFiles)
            {
                foreach (var plugin in manager.Plugins)
                {

                    await plugin.Parse(file);
                }

            }
            return null;
        }
    }
}
