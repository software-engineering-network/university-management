using System.Windows.Controls;
using UniversityManagement.Services.Enrollment;

namespace UniversityManagement.Wpf.Enrollment
{
    /// <summary>
    /// Interaction logic for ApplicantView.xaml
    /// </summary>
    public partial class ApplicantView : UserControl
    {
        public ApplicantDto Applicant { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ApplicantView()
        {
            InitializeComponent();
        }
    }
}
