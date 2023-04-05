using DoctorWho.Domain;
using System;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeEnemiesRepository
    {
        public static void AddEnemyToEpisode(Enemy Enemy, int EpisodeId)
        {
            if (Enemy == null) throw new ArgumentNullException("Invalid input! Please provide an enemy instance that is NOT NULL...");
            var episode = DoctorWhoCoreDbContext._context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeEnemies.Add(new EpisodeEnemy { EnemyId = Enemy.EnemyId, EpisodeId = EpisodeId });
                DoctorWhoCoreDbContext._context.SaveChanges();
            }
            else throw new InvalidOperationException("No episodes with the provided Id exist in the database!");
        }
    }
}