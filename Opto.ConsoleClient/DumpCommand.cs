using System.Text;

namespace Opto.ConsoleClient
{
    public class DumpCommand : IOptoCommandWithHelp
    {
        private readonly IConsoleWriter _writer;

        public DumpCommand(IConsoleWriter writer)
        {
            _writer = writer;
        }

        public virtual void Execute(string[] args)
        {
            // TODO
            var filename = args[0];
            _writer.WriteLine($"TODO: I will be able to dump {filename}.");
        }

        public virtual string HelpText
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine("Usage: opto dump <file>");
                sb.AppendLine();
                sb.AppendLine("    <file>   The file to be dumped");
                return sb.ToString();
            }
        }

        public virtual string Key { get; } = "dump";
    }
}