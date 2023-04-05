using DoctorWho.Domain;
using System;

namespace DoctorWho.Db.Repositories
{
    public class EpisodesRepository
    {
        public static void Create(int? SeriesNumber, int? EpisodeNumber, string EpisodeType, string Title, DateTime? EpisodeDate, int AuthorId, DoctorIdEnum DoctorId, string Notes)
        {
            if (Title == null) throw new ArgumentNullException("Cannot create an Episode with a null Title!");
            DoctorWhoCoreDbContext._context.Episodes.Add(new Episode(SeriesNumber, EpisodeNumber, EpisodeType, Title, EpisodeDate, AuthorId, DoctorId, Notes));
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Update()
        {
            DoctorWhoCoreDbContext._context.ChangeTracker.DetectChanges();
            DoctorWhoCoreDbContext._context.SaveChanges();
        }
        public static void Delete(Episode Episode)
        {
            if (Episode == null) throw new ArgumentNullException("Cannot remove a null Episode from the Episodes table");
            try
            {
                DoctorWhoCoreDbContext._context.Episodes.Remove(Episode);
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}