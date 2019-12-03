using Autofac;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Services
{
    public class ServicesModule : Module
    {
        #region Module Overrides

        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
        }

        #endregion

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<CreateApplicationService>().As<ICreateApplicationService>();
        }
    }
}
