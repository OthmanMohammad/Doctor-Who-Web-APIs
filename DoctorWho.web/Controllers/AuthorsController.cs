// AuthorsController.cs
using DoctorWho.web.DTOs;
using DoctorWho.Db.Repositories;
using DoctorWho.Domain;
using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db;

namespace DoctorWho.web.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        [HttpPut("{authorId}")]
        public IActionResult UpdateAuthor(int authorId, [FromBody] AuthorDto authorUpdateDto)
        {
            Author author = DoctorWhoCoreDbContext._context.Authors.Find(authorId);

            if (author == null)
            {
                return NotFound("Author not found");
            }

            author.AuthorName = authorUpdateDto.AuthorName;
            AuthorsRepository.Update();

            return NoContent();
        }
    }
}
