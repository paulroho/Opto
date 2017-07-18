namespace Opto.ConsoleClient
{
    public interface IOptoMain
    {
        void Execute(params string[] args);
    }

    public class OptoMain : IOptoMain
    {
        private readonly IUsagePrinter _usagePrinter;

        public OptoMain(IUsagePrinter usagePrinter)
        {
            _usagePrinter = usagePrinter;
        }

        public void Execute(params string[] args)
        {
            _usagePrinter.PrintCommonUsageInfo();
        }
    }
}
