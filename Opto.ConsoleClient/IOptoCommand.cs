namespace Opto.ConsoleClient
{
    public interface IOptoCommand
    {
        void Execute(string[] args);
        string HelpText { get; }
        string Key { get; }
    }
}