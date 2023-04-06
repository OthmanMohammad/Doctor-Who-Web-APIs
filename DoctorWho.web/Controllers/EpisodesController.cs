using DoctorWho.Db.Repositories;
using DoctorWho.Domain;
using DoctorWho.web.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DoctorWho.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodesRepository _episodesRepository;

        public EpisodesController(IEpisodesRepository episodesRepository)
        {
            _episodesRepository = episodesRepository;
        }

        [HttpPost]
        public IActionResult CreateEpisode([FromBody] EpisodeDto episodeDto)
        {
            _episodesRepository.Create(episodeDto.SeriesNumber, episodeDto.EpisodeNumber, episodeDto.Title, episodeDto.EpisodeDate, episodeDto.AuthorId, episodeDto.DoctorId, episodeDto.Notes);
            return Ok("Episode created successfully");
        }

        [HttpPut]
        public IActionResult UpdateEpisode([FromBody] EpisodeDto episodeDto)
        {
            var episode = new Episode
            {
                EpisodeId = episodeDto.EpisodeId,
                SeriesNumber = episodeDto.SeriesNumber,
                EpisodeNumber = episodeDto.EpisodeNumber,
                Title = episodeDto.Title,
                EpisodeDate = episodeDto.EpisodeDate,
                AuthorId = episodeDto.AuthorId,
                DoctorId = episodeDto.DoctorId,
                Notes = episodeDto.Notes
            };

            _episodesRepository.Update(episode);
            return Ok("Episode updated successfully");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEpisode(int id)
        {
            Episode episode = _episodesRepository.GetById(id);
            if (episode == null) return NotFound("Episode not found");

            _episodesRepository.Delete(episode);
            return Ok("Episode deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetEpisodeById(int id)
        {
            Episode episode = _episodesRepository.GetById(id);
            if (episode == null) return NotFound("Episode not found");

            return Ok(episode);
        }

        [HttpGet]
        public IActionResult GetAllEpisodes()
        {
            var episodes = _episodesRepository.GetAll();
            return Ok(episodes);
        }
    }
}