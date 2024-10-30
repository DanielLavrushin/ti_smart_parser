namespace Smart.Parser.Core
{
    public interface IPluginOptions
    {
        string InputPath { get; set; }
        string OutputPath { get; set; }
        string[] AllowedExtensions { get; }
        ICollection<FileInfo> InputFiles { get; }
        ICollection<FileInfo> CollectFiles();
    }
    public class PluginOptions : IPluginOptions
    {
        public string InputPath { get; set; }
        public string[] AllowedExtensions { get; } = [".doc", ".docx", ".pdf"];
        public string OutputPath { get; set; }
        public ICollection<FileInfo> InputFiles { get; set; } = new List<FileInfo>();
        public static IPluginOptions Instance { get; set; }

        public PluginOptions()
        {
        }

        public ICollection<FileInfo> CollectFiles()
        {

            if (File.Exists(InputPath))
            {
                InputFiles.Add(new FileInfo(InputPath));
                return InputFiles;
            }

            if (Directory.Exists(InputPath))
            {

                foreach (var file in Directory.GetFiles(InputPath))
                {
                    if (AllowedExtensions.Contains(Path.GetExtension(file)))
                    {
                        InputFiles.Add(new FileInfo(file));
                    }
                }
            }
            return InputFiles;
        }

    }
}
