using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Domain
{
    public class EpisodeCompanion
    {
        // Id for EpisodeCompanion
        public int EpisodeCompanionId { get; set; }
        // Id for Episode
        public int EpisodeId { get; set; }

        // Episode object not mapped to database
        [NotMapped]
        public Episode Episode { get; set; }
        public int CompanionId { get; set; }

        // Companion object not mapped to database
        [NotMapped]
        public Companion Companion { get; set; }
    }
}
