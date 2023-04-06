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
    public class CompanionsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CompanionsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCompanion([FromBody] CompanionDto companionDto)
        {
            var companion = _mapper.Map<Companion>(companionDto);
            CompanionsRepository.Create(companion.CompanionName, companion.WhoPlayed);
            return Ok("Companion created successfully");
        }

        // Add other actions for the Companion entity as needed, such as Get, Update, and Delete.
    }
}
