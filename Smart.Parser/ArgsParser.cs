using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Smart.Parser
{
    public enum ArgType
    {
        Input,
        Output
    }
    public static class ArgValidator
    {
        public static IDictionary<ArgType, Func<IDictionary<ArgType, ArgParameter>, KeyValuePair<string, string>, string>> ValidationRules { get; } = new Dictionary<ArgType, Func<IDictionary<ArgType, ArgParameter>, KeyValuePair<string, string>, string>>()
      {
          {
                ArgType.Input, (args, kv) => ValidatePath(ArgType.Input, kv.Value)
            },
          {
                ArgType.Output, (args, kv) => ValidatePath(ArgType.Output, kv.Value)
          }
      };
        static string ValidatePath(ArgType type, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return $"{type}: file path is not specified";
            }

            if (File.Exists(path) || Directory.Exists(path))
            {
                return null;
            }

            return $"{type}: Specified path does not exist";
        }
    }

    public interface IArgParameter
    {
        ArgType Type { get; set; }
        string Value { get; set; }

    }

    public class ArgParameter : IArgParameter
    {
        public ArgType Type { get; set; }
        public string Value { get; set; }

        public ArgParameter(ArgType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
    public interface IArgsParser
    {
        IReadOnlyDictionary<ArgType, ArgParameter> Args { get; }
        IPluginOptions CreatePluginOptions();
    }
    public class ArgsParser : IArgsParser
    {
        #region static members
        public static ArgsParser Instance { get; private set; }
        internal static ArgsParser Instanate(string[] args)
        {
            return Instance = new ArgsParser(args);
        }
        #endregion

        #region arguments list
        private IDictionary<string, string> rawArgs = new Dictionary<string, string>();
        public IReadOnlyDictionary<ArgType, ArgParameter> Args { get; private set; } = new Dictionary<ArgType, ArgParameter>();

        #endregion

        internal ArgsParser(string[] args)
        {
            if (args?.Length > 0)
            {
                ArgsToDictionary(args);
                ParseArgs();
            }
        }

        public IPluginOptions CreatePluginOptions()
        {
            PluginOptions.Instance = new PluginOptions
            {
                InputPath = Args[ArgType.Input].Value,
                OutputPath = Args[ArgType.Output].Value
            };

            return PluginOptions.Instance;
        }

        private void ArgsToDictionary(string[] args)
        {
            if (args?.Length > 0)
            {
                foreach (var arg in args)
                {
                    string key = null;
                    string value = null;
                    if (arg.StartsWith('-'))
                    {
                        key = arg.Trim().ToLower();
                        var next = args.Next(arg);
                        value = next?.StartsWith('-') == true ? null : next;

                        rawArgs[key] = value?.Trim().ToLower();
                    }
                }
            }
        }
        private void ParseArgs()
        {
            var args = new Dictionary<ArgType, ArgParameter>();
            foreach (var arg in rawArgs)
            {
                switch (arg.Key)
                {
                    case "-i":
                    case "--input":
                        args[ArgType.Input] = AddInputParam(ArgType.Input, args, arg);
                        break;
                    case "-o":
                    case "--output":
                        args[ArgType.Output] = AddInputParam(ArgType.Input, args, arg);
                        break;
                    default:
                        throw new InvalidEnumArgumentException($"Invalid argument: {arg.Key}");
                }
            }
            Args = new ReadOnlyDictionary<ArgType, ArgParameter>(args);
        }

        private ArgParameter AddInputParam(ArgType type, IDictionary<ArgType, ArgParameter> args, KeyValuePair<string, string> arg)
        {
            var error = ArgValidator.ValidationRules[type].Invoke(args, arg);
            if (error != null)
            {
                throw new ArgumentException(error);
            }
            return new ArgParameter(type, arg.Value);
        }
    }
}
