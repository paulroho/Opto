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
            OptoMain = new OptoMain(new UsagePrinter());
        }
    }
}
