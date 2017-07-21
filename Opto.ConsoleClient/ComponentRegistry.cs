using Autofac;

namespace Opto.ConsoleClient
{
    internal static class ComponentRegistry
    {
        public static void RegisterComponents(this ContainerBuilder builder)
        {
            builder.RegisterInfrastructure();
            builder.RegisterCommands();
        }

        private static void RegisterInfrastructure(this ContainerBuilder builder)
        {
            builder.RegisterType<OptoMain>().AsImplementedInterfaces();
            builder.RegisterType<UsagePrinter>().AsImplementedInterfaces();
            builder.RegisterType<ConsoleWriter>().AsImplementedInterfaces();
        }

        private static void RegisterCommands(this ContainerBuilder builder)
        {
            builder.RegisterType<DumpCommand>().AsImplementedInterfaces();
        }
    }
}