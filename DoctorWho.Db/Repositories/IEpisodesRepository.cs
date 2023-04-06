using DoctorWho.Domain;
using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Repositories
{
    public interface IEpisodesRepository
    {
        void Create(int? SeriesNumber, int? EpisodeNumber, string Title, DateTime? EpisodeDate, int AuthorId, DoctorIdEnum DoctorId, string Notes);
        void Update(Episode episode);
        void Delete(Episode Episode);
        Episode GetById(int id);
        IEnumerable<Episode> GetAll();
    }
}
