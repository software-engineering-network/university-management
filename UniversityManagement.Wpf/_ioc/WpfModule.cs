using Autofac;
using UniversityManagement.Domain;
using UniversityManagement.Wpf.Enrollment;

namespace UniversityManagement.Wpf
{
    public class WpfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterDomain(builder);
            RegisterViewModels(builder);
        }

        private static void RegisterDomain(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<ApplicationViewModel>();
        }
    }
}
