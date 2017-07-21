namespace Opto.ConsoleClient
{
    public class DumpCommand : IOptoCommand
    {
        public virtual void Execute(string[] args)
        {
            throw new System.NotImplementedException();
        }

        public virtual string HelpText
        {
            get { throw new System.NotImplementedException(); }
        }

        public virtual string Key => "dump";
    }
}