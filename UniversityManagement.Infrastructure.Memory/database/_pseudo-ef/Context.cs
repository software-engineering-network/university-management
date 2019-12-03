using System.Collections.Generic;
using System.Linq;
using UniversityManagement.Domain;
using UniversityManagement.Domain.Write;

namespace UniversityManagement.Infrastructure.Memory.Database
{
    public class Context : IContext
    {
        #region Fields

        private readonly List<ISet> _sets;

        #endregion

        #region Properties

        public Set<Application> Applications { get; }
        public Set<College> Colleges { get; }
        public Set<Discipline> Disciplines { get; }
        public Set<Person> People { get; }
        public Set<Program> Programs { get; }
        public Set<ProgramType> ProgramTypes { get; }

        #endregion

        #region Construction

        public Context()
        {
            Applications = new Set<Application>(CreateApplications());
            Colleges = new Set<College>(CreateColleges());
            Disciplines = new Set<Discipline>(CreateDisciplines());
            People = new Set<Person>(CreatePeople());
            Programs = new Set<Program>(CreatePrograms());
            ProgramTypes = new Set<ProgramType>(CreateProgramTypes());

            _sets = new List<ISet>
            {
                Applications,
                Colleges,
                Disciplines,
                People,
                Programs,
                ProgramTypes
            };
        }

        #endregion

        #region IContext Members

        public void Commit()
        {
            foreach (var set in _sets.Where(set => set.HasChanges))
                set.Commit();
        }

        #endregion

        private static List<Application> CreateApplications()
        {
            return new List<Application>
            {
                new Application(1, 1, 3, 30)
            };
        }

        private static List<College> CreateColleges()
        {
            return new List<College>
            {
                new College(1, "Arts & Sciences"),
                new College(2, "Business Administration"),
                new College(3, "Engineering"),
                new College(4, "Law"),
                new College(5, "Pharmacy"),
                new College(6, "Interdisciplinary Studies")
            };
        }

        private static List<Discipline> CreateDisciplines()
        {
            return new List<Discipline>
            {
                new Discipline(1, 2, "Accounting"),
                new Discipline(2, 2, "Accounting: MSA"),
                new Discipline(3, 1, "Actuarial Science"),
                new Discipline(4, 3, "Advanced Energy"),
                new Discipline(5, 3, "Aerospace Engineering"),
                new Discipline(6, 1, "Applied Statistics"),
                new Discipline(7, 1, "Art"),
                new Discipline(8, 1, "Art Education"),
                new Discipline(9, 1, "Arts Administration"),
                new Discipline(10, 1, "Astronomy"),
                new Discipline(11, 1, "Athletic Training and Pre Program"),
                new Discipline(12, 1, "Behavioral Neuroscience"),
                new Discipline(13, 1, "Biochemistry"),
                new Discipline(14, 3, "Bioengineering"),
                new Discipline(15, 1, "Biology"),
                new Discipline(16, 1, "Biomedical Sciences"),
                new Discipline(17, 2, "Business Administration"),
                new Discipline(18, 2, "Business Analytics"),
                new Discipline(19, 1, "Chemistry"),
                new Discipline(20, 3, "Civil Engineering"),
                new Discipline(21, 1, "Clinical and Counseling Psychology"),
                new Discipline(22, 1, "Communication Studies"),
                new Discipline(23, 3, "Computer Engineering"),
                new Discipline(24, 3, "Computer Science"),
                new Discipline(25, 1, "Construction Management"),
                new Discipline(26, 1, "Creative Writing"),
                new Discipline(27, 1, "Criminal Justice"),
                new Discipline(28, 1, "Dance"),
                new Discipline(29, 6, "Data Analytics"),
                new Discipline(30, 1, "Design"),
                new Discipline(31, 1, "Digital Media Production"),
                new Discipline(32, 1, "Education (Early and Middle Childhood)"),
                new Discipline(33, 3, "Electrical Engineering"),
                new Discipline(34, 3, "Engineering Education"),
                new Discipline(35, 3, "Engineering Exploratory"),
                new Discipline(36, 1, "English Pathway Program"),
                new Discipline(37, 2, "Entrepreneurship"),
                new Discipline(38, 1, "Environmental and Field Biology"),
                new Discipline(39, 3, "Environmental Engineering"),
                new Discipline(40, 6, "Environmental Studies"),
                new Discipline(41, 1, "Exercise Physiology"),
                new Discipline(42, 2, "Finance"),
                new Discipline(43, 1, "Forensic Biology"),
                new Discipline(44, 1, "Gender and Sexuality"),
                new Discipline(45, 1, "Geography"),
                new Discipline(46, 1, "Graphic Design"),
                new Discipline(47, 1, "History"),
                new Discipline(48, 1, "Honors Program"),
                new Discipline(49, 2, "International Business"),
                new Discipline(50, 1, "International Studies"),
                new Discipline(51, 1, "International Theatre Production"),
                new Discipline(52, 1, "Language Arts Education"),
                new Discipline(53, 4, "Law - JD"),
                new Discipline(54, 4, "Law - Pre-Law/3+3"),
                new Discipline(55, 1, "Literature"),
                new Discipline(56, 2, "Management"),
                new Discipline(57, 1, "Manufacturing Technology"),
                new Discipline(58, 2, "Marketing"),
                new Discipline(59, 1, "Mathematics"),
                new Discipline(60, 3, "Mechanical Engineering"),
                new Discipline(61, 6, "Medical Humanities"),
                new Discipline(62, 1, "Medical Laboratory Sciences"),
                new Discipline(63, 1, "Molecular Biology"),
                new Discipline(64, 1, "Multimedia Journalism"),
                new Discipline(65, 1, "Music"),
                new Discipline(66, 1, "Music Applied Studies"),
                new Discipline(67, 1, "Music Education"),
                new Discipline(68, 1, "Music History and Literature"),
                new Discipline(69, 1, "Music Theory and Composition"),
                new Discipline(70, 1, "Musical Theatre"),
                new Discipline(71, 1, "Nursing"),
                new Discipline(72, 2, "Pharmaceutical and Healthcare Business"),
                new Discipline(73, 5, "Pharmacy"),
                new Discipline(74, 1, "Philosophy"),
                new Discipline(75, 1, "Philosophy, Politics, and Economics"),
                new Discipline(76, 1, "Physics"),
                new Discipline(77, 1, "Political Science"),
                new Discipline(78, 1, "Pre-Dentistry"),
                new Discipline(79, 1, "Pre-Medicine"),
                new Discipline(80, 1, "Pre-Occupational Therapy"),
                new Discipline(81, 1, "Pre-Optometry"),
                new Discipline(82, 1, "Pre-Physical Therapy"),
                new Discipline(83, 1, "Pre-Physician Assistant"),
                new Discipline(84, 1, "Professional Writing"),
                new Discipline(85, 1, "Psychology"),
                new Discipline(86, 6, "Public Health"),
                new Discipline(87, 1, "Public History and Museum Studies"),
                new Discipline(88, 1, "Public Policy"),
                new Discipline(89, 2, "Public Relations"),
                new Discipline(90, 1, "Religion"),
                new Discipline(91, 3, "Robotics"),
                new Discipline(92, 1, "Social Media"),
                new Discipline(93, 1, "Social Studies"),
                new Discipline(94, 1, "Sociology"),
                new Discipline(95, 1, "Sound Recording Technology"),
                new Discipline(96, 1, "Spanish"),
                new Discipline(97, 2, "Sport Management"),
                new Discipline(98, 1, "Statistics"),
                new Discipline(99, 1, "Strength and Conditioning"),
                new Discipline(100, 1, "Studio Arts"),
                new Discipline(101, 1, "Technology Education"),
                new Discipline(102, 1, "Technology Systems"),
                new Discipline(103, 1, "Theatre"),
                new Discipline(104, 1, "Theatre Technology and Design"),

                //new Discipline(105, 1, "Undecided"),
                new Discipline(106, 1, "Youth Ministry")
            };
        }

        private static List<Person> CreatePeople()
        {
            return new List<Person>
            {
                new Person(1, "John", "Doe", "111-11-1111")
            };
        }

        private static List<Program> CreatePrograms()
        {
            return new List<Program>
            {
                new Program(1, 1, 3),
                new Program(2, 2, 2),
                new Program(3, 3, 1),
                new Program(4, 4, 1),
                new Program(5, 5, 1),
                new Program(6, 6, 1),
                new Program(7, 7, 4),
                new Program(8, 8, 3),
                new Program(9, 9, 4),
                new Program(10, 10, 1),
                new Program(11, 10, 4),
                new Program(12, 11, 3),
                new Program(13, 11, 6),
                new Program(14, 12, 1),
                new Program(15, 13, 3),
                new Program(16, 13, 4),
                new Program(17, 14, 1),
                new Program(18, 15, 3),
                new Program(19, 15, 4),
                new Program(20, 16, 4),
                new Program(21, 17, 4),
                new Program(22, 18, 4),
                new Program(23, 19, 3),
                new Program(24, 19, 4),
                new Program(25, 20, 3),
                new Program(26, 21, 1),
                new Program(27, 22, 3),
                new Program(28, 22, 4),
                new Program(29, 23, 3),
                new Program(30, 24, 3),
                new Program(31, 24, 4),
                new Program(32, 25, 3),
                new Program(33, 26, 3),
                new Program(34, 26, 4),
                new Program(35, 27, 3),
                new Program(36, 27, 4),
                new Program(37, 28, 4),
                new Program(38, 29, 3),
                new Program(39, 29, 4),
                new Program(40, 30, 4),
                new Program(41, 31, 4),
                new Program(42, 32, 3),
                new Program(43, 33, 3),
                new Program(44, 34, 3),
                new Program(45, 35, 5),
                new Program(46, 36, 5),
                new Program(47, 37, 4),
                new Program(48, 38, 3),
                new Program(49, 39, 1),
                new Program(50, 40, 4),
                new Program(51, 41, 1),
                new Program(52, 41, 3),
                new Program(53, 41, 4),
                new Program(54, 42, 3),
                new Program(55, 43, 3),
                new Program(56, 44, 4),
                new Program(57, 45, 4),
                new Program(58, 46, 3),
                new Program(59, 47, 3),
                new Program(60, 47, 4),
                new Program(61, 48, 1),
                new Program(62, 49, 4),
                new Program(63, 50, 4),
                new Program(64, 51, 3),
                new Program(65, 52, 3),
                new Program(66, 52, 6),
                new Program(67, 53, 2),
                new Program(68, 54, 3),
                new Program(69, 55, 3),
                new Program(70, 55, 4),
                new Program(71, 56, 3),
                new Program(72, 56, 4),
                new Program(73, 56, 6),
                new Program(74, 57, 3),
                new Program(75, 58, 3),
                new Program(76, 58, 4),
                new Program(77, 59, 1),
                new Program(78, 59, 3),
                new Program(79, 59, 4),
                new Program(80, 60, 3),
                new Program(81, 61, 4),
                new Program(82, 62, 3),
                new Program(83, 63, 3),
                new Program(84, 64, 3),
                new Program(85, 64, 4),
                new Program(86, 65, 3),
                new Program(87, 65, 4),
                new Program(88, 66, 1),
                new Program(89, 67, 3),
                new Program(90, 68, 1),
                new Program(91, 69, 1),
                new Program(92, 70, 3),
                new Program(93, 71, 3),
                new Program(94, 72, 3),
                new Program(95, 73, 3),
                new Program(96, 73, 2),
                new Program(97, 74, 3),
                new Program(98, 74, 4),
                new Program(99, 75, 3),
                new Program(100, 76, 1),
                new Program(101, 76, 3),
                new Program(102, 76, 4),
                new Program(103, 77, 3),
                new Program(104, 77, 4),
                new Program(105, 78, 6),
                new Program(106, 79, 6),
                new Program(107, 80, 6),
                new Program(108, 81, 6),
                new Program(109, 82, 6),
                new Program(110, 83, 6),
                new Program(111, 84, 3),
                new Program(112, 84, 4),
                new Program(113, 85, 1),
                new Program(114, 85, 3),
                new Program(115, 85, 4),
                new Program(116, 86, 3),
                new Program(117, 86, 4),
                new Program(118, 87, 4),
                new Program(119, 88, 4),
                new Program(120, 89, 3),
                new Program(121, 89, 4),
                new Program(122, 90, 3),
                new Program(123, 90, 4),
                new Program(124, 91, 1),
                new Program(125, 92, 4),
                new Program(126, 93, 3),
                new Program(127, 94, 1),
                new Program(128, 94, 3),
                new Program(129, 94, 4),
                new Program(130, 95, 1),
                new Program(131, 96, 3),
                new Program(132, 96, 4),
                new Program(133, 97, 3),
                new Program(134, 98, 3),
                new Program(135, 99, 1),
                new Program(136, 100, 3),
                new Program(137, 100, 4),
                new Program(138, 101, 3),
                new Program(139, 102, 4),
                new Program(140, 103, 3),
                new Program(141, 103, 4),
                new Program(142, 104, 4),

                //new Program(143, 105, 3),
                new Program(144, 106, 3)
            };
        }

        private static List<ProgramType> CreateProgramTypes()
        {
            return new List<ProgramType>
            {
                new ProgramType(1, "Concentration"),
                new ProgramType(2, "Graduate Program"),
                new ProgramType(3, "Major"),
                new ProgramType(4, "Minor"),
                new ProgramType(5, "Pathway"),
                new ProgramType(6, "Preprofessional Program")
            };
        }
    }
}
