namespace Opto.ConsoleClient
{
    public interface IOptoCommand
    {
        void Execute(string[] args);
        string Key { get; }
    }

    public interface IOptoCommandWithHelp : IOptoCommand
    {
        string HelpText { get; }
    }
}