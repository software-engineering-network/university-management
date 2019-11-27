using Autofac;
using UniversityManagement.Services.Enrollment;
using UniversityManagement.Services.Enrollment.Read;

namespace UniversityManagement.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationReadService>().As<IApplicationReadService>();
            builder.RegisterType<CollegeReadService>().As<ICollegeReadService>();
            builder.RegisterType<ProgramReadService>().As<IProgramReadService>();

            builder.RegisterType<EditApplicationService>().As<IEditApplicationService>();
        }
    }
}
