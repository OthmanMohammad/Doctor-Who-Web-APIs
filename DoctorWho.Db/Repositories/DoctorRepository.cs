using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorWho.Db.Repositories
{
    public class DoctorsRepository
    {
        public static void Create(DoctorIdEnum DoctorId, int DoctorNumber, string DoctorName, DateTime? BirthDate, DateTime? FirstEpisodeDate, DateTime? LastEpisodeDate)
        {
            if (DoctorName == null) throw new ArgumentNullException("Cannot create a Doctor with a null DoctorName!");
            DoctorWhoCoreDbContext._context.Doctors.Add(new Doctor(DoctorId, DoctorNumber, DoctorName, BirthDate, FirstEpisodeDate, LastEpisodeDate));
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Update()
        {
            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Delete(Doctor Doctor)
        {
            if (Doctor == null) throw new ArgumentNullException("Cannot remove a null Doctor from the Doctors table");
            try
            {
                DoctorWhoCoreDbContext._context.Doctors.Remove(Doctor);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Doctor> GetAllDoctors()
        {
            return DoctorWhoCoreDbContext._context.Doctors.ToList();
        }
    }
}