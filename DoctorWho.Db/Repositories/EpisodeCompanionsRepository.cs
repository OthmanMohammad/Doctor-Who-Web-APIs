using DoctorWho.Domain;
using System;

namespace DoctorWho.Db.Repositories
{
    /*
     * This class contains a single static method AddCompanionToEpisode which takes two parameters:
     * 1. Companion: an instance of the Companion class from the DoctorWho.Domain
     * 2. EpisodeId: an integer representing the id of an episode.
     * The method first checks if the Companion instance is null, and if so, throws an ArgumentNullException.
     * Next, the method finds the episode with the provided EpisodeId by calling the Find
     * method on the Episodes property of the DoctorWhoCoreDbContext._context instance.
     * If the episode is not null, the method creates a new EpisodeCompanion instance and
     * adds it to the EpisodeCompanions property of the episode instance. Finally, the method
     * calls the SaveChanges method on the DoctorWhoCoreDbContext._context instance to persist
     * the changes to the database.
     * If the episode is null, the method throws an InvalidOperationException with the message
     * "No episodes with the provided Id exist in the database!".
     * 
     */
    public class EpisodeCompanionsRepository
    {
        public static void AddCompanionToEpisode(Companion Companion, int EpisodeId)
        {
            if (Companion == null) throw new ArgumentNullException("Invalid input! Please provide a companion instance that is NOT NULL...");
            var episode = DoctorWhoCoreDbContext._context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { CompanionId = Companion.CompanionId, EpisodeId = EpisodeId });
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            else throw new InvalidOperationException("No episodes with the provided Id exist in the database!");
        }
    }
}