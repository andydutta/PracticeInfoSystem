using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeInfoSystem;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        // GET: api/Doctors
        [HttpGet("[action]")]
        public IEnumerable<DoctorModel> AllDoctors()
        {
            var model=new List<DoctorModel>();

            using (var dataAccess = new DataAccess())
            {
                
                var doctors = dataAccess.GetAllDoctors().ToList();
                foreach (var doctor in doctors)
                {
                    var doctorModel = new DoctorModel
                    {
                        Id = (int) doctor.Id,
                        Name = doctor.Name,
                        Gender = doctor.Gender,
                        Specialties = string.Join(",", dataAccess.GetDoctorSpecialties(doctor.Id).ToList()),
                        AveragePatientRating = dataAccess.GetRatingOfDoctor(doctor.Id).ToList().Average()
                            .ToString(CultureInfo.InvariantCulture)
                    };
                    model.Add(doctorModel);
                }

                
            }

            return model;
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorDetail(int id)
        {
            
            using (var dataAccess = new DataAccess())
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var doctor = dataAccess.GetAllDoctors().FirstOrDefault(r => r.Id == id);
                if (doctor == null)
                {
                    return NotFound();
                }
                else
                {
                    var doctorDetailsModel = new DoctorDetailsModel
                    {
                        Id = (int) doctor.Id,
                        Name = doctor.Name,
                        SpokenLanguage = string.Join(",", dataAccess.GetSpokenLanguage(doctor).ToList()),
                        MedicalSchoolAttended = string.Join(",", dataAccess.GetSchools(doctor).ToList()),
                        PatientReviews = string.Join(",", dataAccess.GetReviews(doctor).ToList()),
                        IsSuperStar = dataAccess.GetAverageRatingOfDoctor(doctor.Id, 5)
                    };

                    return Ok(doctorDetailsModel);

                }
            }
        }

    }
}