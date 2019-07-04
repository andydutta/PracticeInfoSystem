using System;
using System.Collections.Generic;

namespace PracticeInfoSystem
{
    public partial class DoctorSpecialty
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public long SpecialtyId { get; set; }

        public Doctor Doctor { get; set; }
        public Specialty Specialty { get; set; }
    }
}
