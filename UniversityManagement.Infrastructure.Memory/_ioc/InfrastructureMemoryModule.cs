using Autofac;
using UniversityManagement.Domain.Enrollment;
using UniversityManagement.Infrastructure.Memory.Enrollment;

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
        }
    }
}
