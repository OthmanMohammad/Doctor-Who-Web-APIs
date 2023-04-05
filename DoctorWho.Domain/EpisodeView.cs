namespace DoctorWho.Domain
{
    // The EpisodeView class is a view model class in the DoctorWho.Domain namespace.
    // The purpose of the EpisodeView class is to provide a convenient way to access and display relevant
    // information about an episode, which contains data from multiple entities related to the episode,
    // without having to deal with all of the details stored in the full Episode class.
    public class EpisodeView
    {
        public int? Series_Number { get; set; }
        public int? Episode_Number { get; set; }
        public string Title { get; set; }
        public string Author_Name { get; set; }
        public string Doctor_Name { get; set; }
        public string Companions { get; set; }
        public string Enemies { get; set; }
    }
}