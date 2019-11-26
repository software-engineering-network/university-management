using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Enrollment;

namespace UniversityManagement.Services.Enrollment
{
    public class ProgramReadService : IProgramReadService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProgramReadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
                .ToList();

            return majors;
        }
    }

    public static class MajorDtoExtensions
    {
        public static IEnumerable<MajorDto> WithCollegesAndDisciplines(
            this IEnumerable<Major> source,
            IEnumerable<College> colleges,
            IEnumerable<Discipline> disciplines
        )
        {
            return source
                .Join(
                    colleges,
                    major => major.CollegeId,
                    college => college.Id,
                    (Major, College) => new { Major, College }
                )
                .Join(
                    disciplines,
                    majorCollege => majorCollege.Major.DisciplineId,
                    discipline => discipline.Id,
                    (majorCollege, Discipline) => new MajorDto
                    {
                        Id = majorCollege.Major.Id,
                        College = Mapper.Map<College, CollegeDto>(majorCollege.College),
                        Discipline = Mapper.Map<Discipline, DisciplineDto>(Discipline)
                    }
                );
        }
    }
}
