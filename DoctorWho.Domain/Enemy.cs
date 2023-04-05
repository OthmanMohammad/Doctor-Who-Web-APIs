using System.Collections.Generic;

namespace DoctorWho.Domain
{
    // Class representing the enemy entity in the Doctor Who domain
    public class Enemy
    {
        // Default constructor initializing the EpisodeEnemies property
        public Enemy()
        {
            this.EpisodeEnemies = new List<EpisodeEnemy>();
        }

        // Constructor taking in the enemy name and description and initializing the EpisodeEnemies property
        public Enemy(string EnemyName, string Description) : this()
        {
            this.EnemyName = EnemyName;
            this.Description = Description;
        }

        // Property for the enemy's unique identifier
        public int EnemyId { get; set; }

        public string EnemyName { get; set; }

        public string Description { get; set; }

        // Property representing the relationships between the enemy and its related episode entities
        public List<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}