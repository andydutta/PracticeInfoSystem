using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Core.Models;
using PracticeInfoSystem;

namespace Core.Repository
{
    public class DataAccess : IDisposable
    {
        private medpracticeContext _context;

        public DataAccess()
        {
            _context = new medpracticeContext();
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctor.Select(r => r);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //var dataModels = new List<DoctorModel>();
        //var data = (from doctor in _context.Doctor
        //        join specialty in _context.DoctorSpecialty on doctor.Id equals specialty.DoctorId
        //        join rating in _context.PatientRating on doctor.Id equals rating.DoctorId
        //        select new DoctorModel
        //        {
        //            Id = (int)doctor.Id,
        //            Name = doctor.Name,
        //            Gender = doctor.Gender,
        //            Specialties = specialty.Specialty.Name,
        //            AveragePatientRating = rating.Rating
        //        }).Distinct();


        //    return data;
        public IEnumerable<string> GetDoctorSpecialties(long doctorId)
        {
            var data = _context.DoctorSpecialty.Where(r => r.DoctorId == (int) doctorId).Select(r => r.Specialty.Name);
            return data;
        }

        public IQueryable<int> GetRatingOfDoctor(long doctorId)
        {
            var data = _context.PatientRating.Where(r => r.DoctorId == (int) doctorId).Select(r => r.Rating);
            return data;
        }

        public IQueryable<string> GetSpokenLanguage(Doctor doctorId)
        {
            var data=_context.Language.Where(m=>m.Doctor.Contains(doctorId)).Select(r=>r.Name);
            return data;
        }

        public IEnumerable<string> GetSchools(Doctor doctor)
        {
            var data = _context.MedicalSchool.Where(m => m.Doctor.Contains(doctor)).Select(m => m.Name);
            return data;
        }

        public IEnumerable<string> GetReviews(Doctor doctor)
        {
            var data = _context.PatientRating.Where(m => m.Doctor.Equals(doctor)).Select(m => m.Comments);
            return data;
        }

        public bool GetAverageRatingOfDoctor(long doctorId, int i)
        {
            var totalFiveRatingCount = _context.PatientRating.Where(r => r.DoctorId == (int)doctorId&&r.Rating.Equals(i)).Select(r => r.Rating).Count();
            var totalRatingCount = _context.PatientRating.Where(r => r.DoctorId == (int) doctorId).Select(r => r.Rating)
                .Count();
            var result = totalFiveRatingCount / totalRatingCount * 100;
            return result >= 85;
        }
    }

}
