using Autofac;
using UniversityManagement.Domain.Write.Enrollment;

namespace UniversityManagement.Domain
{
    public class DomainModule : Module
    {
        #region Module Overrides

        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
            RegisterValidators(builder);
        }

        #endregion

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationProcessor>().As<IApplicationProcessor>();
        }

        private static void RegisterValidators(ContainerBuilder builder)
        {
            builder.RegisterType<CreateApplicationValidator>();
        }
    }
}
