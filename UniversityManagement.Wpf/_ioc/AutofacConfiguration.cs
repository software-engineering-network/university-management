using Autofac;
using UniversityManagement.Infrastructure.Memory;
using UniversityManagement.Services;

namespace UniversityManagement.Wpf
{
    public class AutofacConfiguration
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            RegisterModules(builder);

            return builder.Build();
        }

        public static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructureMemoryModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<WpfModule>();
        }
    }
}
