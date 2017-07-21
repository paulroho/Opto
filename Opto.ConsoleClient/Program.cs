using Autofac;

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
            var builder = new ContainerBuilder();
            builder.RegisterComponents();
            var container = builder.Build();

            OptoMain = container.Resolve<IOptoMain>();
        }
    }
}
