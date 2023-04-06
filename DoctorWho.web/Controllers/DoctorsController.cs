using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db.Repositories;
using DoctorWho.web.DTOs;
using AutoMapper;
using DoctorWho.Domain;


namespace DoctorWho.web.Controllers
{
    public class DoctorsController : Controller
    {

        private readonly DoctorsRepository _doctorsRepository;
        private readonly IMapper _mapper;

        public DoctorsController(DoctorsRepository doctorsRepository, IMapper mapper)
        {
            _doctorsRepository = doctorsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var doctors = _doctorsRepository.GetAllDoctors();
            var doctorDtos = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return Ok(doctorDtos);
        }

        [HttpPost]
        public IActionResult Upsert([FromBody] DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            var upsertedDoctor = _doctorsRepository.Upsert(doctor);
            var upsertedDoctorDto = _mapper.Map<DoctorDto>(upsertedDoctor);

            return Ok(upsertedDoctorDto);
        }


    }
}
