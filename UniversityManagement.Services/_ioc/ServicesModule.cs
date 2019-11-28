using Autofac;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Services
{
    public class ServicesModule : Module
    {
        #region Module Overrides

        protected override void Load(ContainerBuilder builder)
        {
            RegisterReadServices(builder);
            RegisterCompositeServices(builder);
        }

        #endregion

        private static void RegisterCompositeServices(ContainerBuilder builder)
        {
            builder.RegisterType<EditApplicationService>().As<IEditApplicationService>();
        }

        private static void RegisterReadServices(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationReadService>().As<IApplicationReadService>();
            builder.RegisterType<CollegeReadService>().As<ICollegeReadService>();
            builder.RegisterType<ProgramReadService>().As<IProgramReadService>();
        }
    }
}
