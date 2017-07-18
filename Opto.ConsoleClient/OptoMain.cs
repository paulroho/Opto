using System;

namespace Opto.ConsoleClient
{
    public interface IOptoMain
    {
        void Execute(string[] args);
    }

    public class OptoMain : IOptoMain
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("usage");
        }
    }
}
