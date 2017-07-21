namespace Opto.ConsoleClient
{
    public static class Program
    {
        static Program()
        {
            ResetOptoMain();
        }

        public static void Main(string[] args)
        {
            OptoMain.Execute(args);
        }

        public static IOptoMain OptoMain { get; set; }

        public static void ResetOptoMain()
        {
            var writer = new ConsoleWriter();
            OptoMain = new OptoMain(new UsagePrinter(writer), new IOptoCommand[] {new DumpCommand(writer)});
        }
    }
}
