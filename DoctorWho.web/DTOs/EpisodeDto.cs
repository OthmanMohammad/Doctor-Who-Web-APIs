using DoctorWho.Domain;
public class EpisodeDto
{
    public int EpisodeId { get; set; }
    public int? SeriesNumber { get; set; }
    public int? EpisodeNumber { get; set; }
    public string Title { get; set; }
    public DateTime EpisodeDate { get; set; }
    public int AuthorId { get; set; }
    public DoctorIdEnum DoctorId { get; set; }
    public string Notes { get; set; }
}
