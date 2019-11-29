using System;

namespace UniversityManagement.Domain
{
    [Flags]
    public enum ProgramType
    {
        None = 0,
        Concentration = 1,
        GraduateProgram = 1 << 1,
        Major = 1 << 2,
        Minor = 1 << 3,
        Pathway = 1 << 4,
        PreprofessionalProgram = 1 << 5,
        Primary = GraduateProgram | Major | Pathway | PreprofessionalProgram
    }
}
