using AutoMapper;
using DoctorWho.Db.Repositories;
using DoctorWho.Domain;
using DoctorWho.web.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DoctorWho.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnemiesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public EnemiesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateEnemy([FromBody] EnemyDto enemyDto)
        {
            var enemy = _mapper.Map<Enemy>(enemyDto);
            EnemiesRepository.Create(enemy.EnemyName, enemy.Description);
            return Ok("Enemy created successfully");
        }

        // Add other actions for the Enemy entity as needed, such as Get, Update, and Delete.
    }
}
