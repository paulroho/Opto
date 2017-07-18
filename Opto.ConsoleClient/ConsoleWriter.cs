using System;

namespace Opto.ConsoleClient
{
    public interface IConsoleWriter
    {
        void WriteLine(string line);
    }

    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}