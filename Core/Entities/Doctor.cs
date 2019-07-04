using System;
using System.Collections.Generic;

namespace PracticeInfoSystem
{
    public partial class Doctor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public long MedicalSchoolId { get; set; }
        public long LanguageId { get; set; }

        public Language Language { get; set; }
        public MedicalSchool MedicalSchool { get; set; }
        public DoctorSpecialty DoctorSpecialty { get; set; }
        public PatientRating PatientRating { get; set; }
    }
}
