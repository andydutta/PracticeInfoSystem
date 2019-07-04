using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class DoctorDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpokenLanguage { get; set; }
        public string MedicalSchoolAttended { get; set; }
        public string PatientReviews { get; set; }
        public bool IsSuperStar { get; set; }
    }
}
