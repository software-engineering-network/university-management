using Autofac;
using UniversityManagement.Services.Enrollment;

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
            builder.RegisterType<CollegeReadService>().As<ICollegeReadService>();
            builder.RegisterType<EditApplicationService>().As<IEditApplicationService>();
            builder.RegisterType<ProgramReadService>().As<IProgramReadService>();
        }
    }
}
