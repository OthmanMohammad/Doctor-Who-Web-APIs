// This code defines the EpisodeEnemy class, which represents a relationship between a specific episode and enemy in the DoctorWho domain.

using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Domain
{
    public class EpisodeEnemy
    {
        // The primary key for the EpisodeEnemy class
        public int EpisodeEnemyId { get; set; }

        // The foreign key for the Episode class
        public int EpisodeId { get; set; }

        // The Episode object, but it is not mapped to the database
        [NotMapped]
        public Episode Episode { get; set; }

        // The foreign key for the Enemy class
        public int EnemyId { get; set; }

        // The Enemy object, but it is not mapped to the database
        [NotMapped]
        public Enemy Enemy { get; set; }
    }
}
