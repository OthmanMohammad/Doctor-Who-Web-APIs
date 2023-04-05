// The Episode class represents an episode in the Doctor Who universe
// It contains properties for the episode's ID, series and episode number, episode type, title, air date, author ID, 
// doctor ID, notes, and lists of episode companions and enemies.

using System;
using System.Collections.Generic;

namespace DoctorWho.Domain
{
    public class Episode
    {
        // Default constructor that initializes the EpisodeCompanions and EpisodeEnemies lists
        public Episode()
        {
            this.EpisodeCompanions = new List<EpisodeCompanion>();
            this.EpisodeEnemies = new List<EpisodeEnemy>();
        }

        // Constructor that takes in values for all of the Episode properties and initializes the EpisodeCompanions and EpisodeEnemies lists
        public Episode(int? SeriesNumber, int? EpisodeNumber, string EpisodeType, string Title, DateTime? EpisodeDate, int? AuthorId, DoctorIdEnum DoctorId, string Notes) : this()
        {
            this.SeriesNumber = SeriesNumber;
            this.EpisodeNumber = EpisodeNumber;
            this.EpisodeType = EpisodeType;
            this.Title = Title;
            this.EpisodeDate = EpisodeDate;
            this.AuthorId = AuthorId;
            this.DoctorId = DoctorId;
            this.Notes = Notes;
        }

        // Properties for the episode's ID, series and episode number, episode type, title, air date, author ID, 
        // doctor ID, and notes
        public int EpisodeId { get; set; }
        public int? SeriesNumber { get; set; }
        public int? EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime? EpisodeDate { get; set; }
        public int? AuthorId { get; set; }
        public DoctorIdEnum DoctorId { get; set; }
        public string Notes { get; set; }

        // Lists of episode companions and enemies
        public List<EpisodeCompanion> EpisodeCompanions { get; set; }
        public List<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}
