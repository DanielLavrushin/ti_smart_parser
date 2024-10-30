
using System.Diagnostics;
using System.Reflection;

namespace Smart.Parser.Plugin.TabulaPdfParser
{
    public class CamelotPdfTableParser : DocumentParser
    {
        public override string Name { get; } = "Camelot PDF Tables Parser";

        public override async Task<string> Parse(FileInfo file)
        {
            var outputDir = Options.OutputPath;
            var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var timeout = TimeSpan.FromSeconds(120);

            var startInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"pdf2json.py \"{file.FullName}\" \"{outputDir}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = assemblyDir
            };

            try
            {
                using (var process = new Process { StartInfo = startInfo })
                {
                    process.Start();

                    var outputTask = process.StandardOutput.ReadToEndAsync();
                    var errorTask = process.StandardError.ReadToEndAsync();
                    var exitTask = process.WaitForExitAsync();

                    if (await Task.WhenAny(exitTask, Task.Delay(timeout)) == exitTask)
                    {
                        // Process exited within the timeout, so continue
                        string output = await outputTask;
                        string error = await errorTask;

                        if (process.ExitCode != 0)
                        {
                            Console.WriteLine("CAMELOT PARSE:\n" + error);
                            throw new Exception($"Python script error: {error}");
                        }

                        Console.WriteLine("CAMELOT PARSE:\n" + output);
                    }
                    else
                    {
                        // Process did not exit in time, so kill it
                        process.Kill();
                        throw new TimeoutException($"Python script timed out for file: {file.Name}");
                    }
                }

                // Continue with checking output file existence, etc.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Parse method: {ex.Message}");
                throw;
            }

            return $"Parsing completed for {file.Name}";

        }
    }
}
