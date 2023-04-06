using DoctorWho.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorWho.Db.Repositories
{
    public class EpisodesRepository : IEpisodesRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public EpisodesRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public void Create(int? SeriesNumber, int? EpisodeNumber, string Title, DateTime? EpisodeDate, int AuthorId, DoctorIdEnum DoctorId, string Notes)
        {
            if (Title == null) throw new ArgumentNullException("Cannot create an Episode with a null Title!");
            _context.Episodes.Add(new Episode(SeriesNumber, EpisodeNumber, null, Title, EpisodeDate, AuthorId, DoctorId, Notes));
            _context.SaveChanges();
        }

        public void Update(Episode episode)
        {
            var existingEpisode = GetById(episode.EpisodeId);
            if (existingEpisode == null) throw new ArgumentException("Episode not found");

            existingEpisode.SeriesNumber = episode.SeriesNumber;
            existingEpisode.EpisodeNumber = episode.EpisodeNumber;
            existingEpisode.EpisodeType = episode.EpisodeType;
            existingEpisode.Title = episode.Title;
            existingEpisode.EpisodeDate = episode.EpisodeDate;
            existingEpisode.AuthorId = episode.AuthorId;
            existingEpisode.DoctorId = episode.DoctorId;
            existingEpisode.Notes = episode.Notes;

            _context.SaveChanges();
        }

        public void Delete(Episode episode)
        {
            if (episode == null) throw new ArgumentNullException(nameof(episode));
            _context.Episodes.Remove(episode);
            _context.SaveChanges();
        }

        public Episode GetById(int id)
        {
            return _context.Episodes.Find(id);
        }

        public IEnumerable<Episode> GetAll()
        {
            return _context.Episodes.ToList();
        }
    }
}
