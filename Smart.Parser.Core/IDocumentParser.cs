namespace Smart.Parser.Core
{

    public interface IDocumentParser
    {
        string Name { get; }
        IPluginOptions Options { get; }
        async Task<string> Parse(FileInfo file)
        {
            return await Task.FromResult(Options.InputPath);
        }
    }

    public abstract class DocumentParser : IDocumentParser
    {
        public abstract string Name { get; }

        public IPluginOptions Options { get; }

        public DocumentParser() : this(PluginOptions.Instance)
        {

        }
        public DocumentParser(IPluginOptions options)
        {
            Options = options;
        }
        public abstract Task<string> Parse(FileInfo file);

    }
}
