using System;

namespace Opto.ConsoleClient
{
    public interface IUsagePrinter
    {
        void PrintCommonUsageInfo();
    }

    class UsagePrinter : IUsagePrinter
    {
        public void PrintCommonUsageInfo()
        {
            Console.WriteLine("usage");
        }
    }
}