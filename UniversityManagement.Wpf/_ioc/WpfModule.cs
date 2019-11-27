using Autofac;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Read;
using UniversityManagement.Infrastructure.Memory.Database;
using UniversityManagement.Wpf.Enrollment;
using UniversityManagement.Wpf.Read;

namespace UniversityManagement.Wpf
{
    public class WpfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterDomain(builder);
            RegisterInfrastructure(builder);
            RegisterViewModels(builder);
        }

        private static void RegisterDomain(ContainerBuilder builder)
        {
            builder.RegisterType<Read.UnitOfWork>().As<Domain.Read.IUnitOfWork>();
            builder.RegisterType<Write.UnitOfWork>().As<Domain.Write.IUnitOfWork>();
        }

        private static void RegisterInfrastructure(ContainerBuilder builder)
        {
            builder.RegisterType<Context>();
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<ApplicationViewModel>();
        }
    }
}
