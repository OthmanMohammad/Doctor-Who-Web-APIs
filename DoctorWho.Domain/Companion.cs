using System.Collections.Generic;

namespace DoctorWho.Domain
{
    public class Companion
    {
        // Default constructor that initializes the EpisodeCompanions list
        public Companion()
        {
            this.EpisodeCompanions = new List<EpisodeCompanion>();
        }

        // Overloaded constructor that takes in the CompanionName and WhoPlayed values and initializes the EpisodeCompanions list
        public Companion(string CompanionName, string WhoPlayed) : this()
        {
            this.CompanionName = CompanionName;
            this.WhoPlayed = WhoPlayed;
        }

        public int CompanionId { get; set; }

        public string CompanionName { get; set; }

        public string WhoPlayed { get; set; }

        public List<EpisodeCompanion> EpisodeCompanions { get; set; }
    }
}
