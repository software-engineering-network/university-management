using Autofac;
using UniversityManagement.Domain.Read.Enrollment;
using UniversityManagement.Infrastructure.Memory.Read.Enrollment;

namespace UniversityManagement.Infrastructure.Memory
{
    public class InfrastructureMemoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterRepositories(builder);
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicantRepository>().As<IApplicantRepository>();
            builder.RegisterType<ApplicationRepository>().As<IApplicationRepository>();
            builder.RegisterType<CollegeRepository>().As<ICollegeRepository>();
            builder.RegisterType<MinorRepository>().As<IMinorRepository>();
            builder.RegisterType<ProgramRepository>().As<IProgramRepository>();
        }
    }
}
