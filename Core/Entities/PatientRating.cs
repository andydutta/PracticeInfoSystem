using System;
using System.Collections.Generic;

namespace PracticeInfoSystem
{
    public partial class PatientRating
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public Doctor Doctor { get; set; }
    }
}
