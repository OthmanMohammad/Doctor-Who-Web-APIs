using System;
using System.Collections.Generic;

namespace DoctorWho.Domain
{
    // A class to represent a Doctor in the Doctor Who universe
    public class Doctor
    {
        // Default constructor that initializes an empty list of episodes
        public Doctor()
        {
            this.Episodes = new List<Episode>();
        }

        // Parameterized constructor that takes in values for properties
        public Doctor(DoctorIdEnum DoctorId, int DoctorNumber, string DoctorName, DateTime? BirthDate, DateTime? FirstEpisodeDate, DateTime? LastEpisodeDate) : this()
        {
            // Assign values to properties
            this.DoctorId = DoctorId;
            this.DoctorNumber = DoctorNumber;
            this.DoctorName = DoctorName;
            this.BirthDate = BirthDate;
            this.FirstEpisodeDate = FirstEpisodeDate;
            this.LastEpisodeDate = LastEpisodeDate;
        }

        // Properties to represent the Doctor's ID, number, name, birthdate, first episode date, and last episode date
        public DoctorIdEnum DoctorId { get; set; }
        public int DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }

        // A list of episodes the doctor has appeared in
        public List<Episode> Episodes { get; set; }
    }
}
