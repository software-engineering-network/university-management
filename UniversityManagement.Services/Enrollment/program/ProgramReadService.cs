using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Services.Enrollment
{
    public class ProgramReadService : IProgramReadService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public ProgramReadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IProgramReadService Members

        public IEnumerable<MajorDto> FetchMajors()
        {
            var colleges = _unitOfWork.CollegeRepository.Fetch();
            var disciplines = _unitOfWork.DisciplineRepository.Fetch();

            var majors = _unitOfWork.MajorRepository
                .Fetch()
                .WithCollegesAndDisciplines(
                    colleges,
                    disciplines
                )
                .Select(Mapper.Map<ProgramDto, MajorDto>)
                .ToList();

            return majors;
        }

        public IEnumerable<MajorDto> FetchMajors(long collegeId)
        {
            var colleges = _unitOfWork.CollegeRepository.Fetch();
            var disciplines = _unitOfWork.DisciplineRepository.Fetch();

            var majors = _unitOfWork.MajorRepository
                .Fetch(collegeId)
                .WithCollegesAndDisciplines(
                    colleges,
                    disciplines
                )
                .Select(Mapper.Map<ProgramDto, MajorDto>)
                .ToList();

            return majors;
        }

        public IEnumerable<MinorDto> FetchMinors()
        {
            var colleges = _unitOfWork.CollegeRepository.Fetch();
            var disciplines = _unitOfWork.DisciplineRepository.Fetch();

            var minors = _unitOfWork.MinorRepository
                .Fetch()
                .WithCollegesAndDisciplines(
                    colleges,
                    disciplines
                )
                .Select(Mapper.Map<ProgramDto, MinorDto>)
                .ToList();

            return minors;
        }

        #endregion
    }

    public static class Extensions
    {
        public static IEnumerable<ProgramDto> WithCollegesAndDisciplines(
            this IEnumerable<Program> source,
            IEnumerable<College> colleges,
            IEnumerable<Discipline> disciplines
        )
        {
            return source
                .WithColleges(colleges)
                .Join(
                    disciplines,
                    x => x.Program.DisciplineId,
                    discipline => discipline.Id,
                    (x, Discipline) => new ProgramDto
                    {
                        Id = x.Program.Id,
                        College = Mapper.Map<College, CollegeDto>(x.College),
                        Discipline = Mapper.Map<Discipline, DisciplineDto>(Discipline)
                    }
                );
        }

        private static IEnumerable<ProgramCollege> WithColleges(
            this IEnumerable<Program> source,
            IEnumerable<College> colleges
        )
        {
            return source
                .Join(
                    colleges,
                    major => major.CollegeId,
                    college => college.Id,
                    (program, college) => new ProgramCollege
                    {
                        Program = program,
                        College = college
                    }
                );
        }

        #region Nested type: ProgramCollege

        private class ProgramCollege
        {
            #region Properties

            public Program Program { get; set; }
            public College College { get; set; }

            #endregion
        }

        #endregion
    }
}
