using System;

namespace Opto.ConsoleClient
{
    public interface IConsoleWriter
    {
        void WriteLine(string line = null);
    }

    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line = null)
        {
            Console.WriteLine(line);
        }
    }
}