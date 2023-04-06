using AutoMapper;
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

        private readonly IMapper _mapper;

        public EpisodesController(IEpisodesRepository episodesRepository, IMapper mapper)
        {
            _episodesRepository = episodesRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult CreateEpisode([FromBody] EpisodeDto episodeDto)
        {
            var episode = _mapper.Map<Episode>(episodeDto);
            _episodesRepository.Create(episode.SeriesNumber, episode.EpisodeNumber, episode.Title, episode.EpisodeDate, episode.AuthorId, episode.DoctorId, episode.Notes);
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
        [HttpPost("{episodeId:int}/enemies/{enemyId:int}")]
        public IActionResult AddEnemyToEpisode(int episodeId, int enemyId)
        {
            _episodesRepository.AddEnemyToEpisode(episodeId, enemyId);
            return Ok("Enemy added to episode successfully");
        }

        [HttpPost("{episodeId:int}/companions/{companionId:int}")]
        public IActionResult AddCompanionToEpisode(int episodeId, int companionId)
        {
            _episodesRepository.AddCompanionToEpisode(episodeId, companionId);
            return Ok("Companion added to episode successfully");
        }

    }
}