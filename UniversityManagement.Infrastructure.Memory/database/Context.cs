using System.Collections.Generic;

namespace UniversityManagement.Infrastructure.Memory
{
    public class Context
    {
        #region Properties

        public List<College> Colleges { get; }
        public List<Discipline> Disciplines { get; }

        #endregion

        #region Construction

        public Context()
        {
            Colleges = CreateColleges();
            Disciplines = CreateDisciplines();
        }

        #endregion

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
                new Discipline(105, 1, "Undecided"),
                new Discipline(106, 1, "Youth Ministry")
            };
        }
    }
}
