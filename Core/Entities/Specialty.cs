using System;
using System.Collections.Generic;

namespace PracticeInfoSystem
{
    public partial class Specialty
    {
        public Specialty()
        {
            DoctorSpecialty = new HashSet<DoctorSpecialty>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<DoctorSpecialty> DoctorSpecialty { get; set; }
    }
}
