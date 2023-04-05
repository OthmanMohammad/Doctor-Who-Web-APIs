using DoctorWho.Domain;
using System;

namespace DoctorWho.Db.Repositories
{
    public class CompanionsRepository
    {
        public static void Create(string CompanionName, string WhoPlayed)
        {
            if (CompanionName == null || WhoPlayed == null)
                throw new ArgumentNullException("Cannot create a Companion with a null CompanionName or a null WhoPlayed!");
            DoctorWhoCoreDbContext._context.Companions.Add(new Companion(CompanionName, WhoPlayed));
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Update()
        {
            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Delete(Companion Companion)
        {
            if (Companion == null) throw new ArgumentNullException("Cannot remove a null Companion from the Companions table");
            try
            {
                DoctorWhoCoreDbContext._context.Companions.Remove(Companion);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Companion GetCompanionById(int CompanionId)
        {
            var companion = DoctorWhoCoreDbContext._context.Companions.Find(CompanionId);
            return companion != null ? companion : throw new NullReferenceException("No companions with the provided Id exist in the database!");
        }
    }
}