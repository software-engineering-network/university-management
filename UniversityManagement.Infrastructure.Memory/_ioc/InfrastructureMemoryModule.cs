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
            builder.RegisterType<CollegeRepository>().As<ICollegeRepository>();
            builder.RegisterType<ProgramRepository>().As<IProgramRepository>();
        }
    }
}
