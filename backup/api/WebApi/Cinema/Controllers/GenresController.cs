using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public GenresController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
            return await _context.Genre.ToListAsync();
        }

        // GET: api/Genres/action
        [HttpGet("{genreId}")]
        public async Task<ActionResult<Genre>> GetGenre(int genreId)
        {
            var genre = await _context.Genre.FindAsync(genreId);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        //[HttpGet("fnavn")]
        //public async Task<ActionResult<Genre>> GetGenreNavn(string fnavn)
        //{
        //    string s = "hans";

        //    return null;
        //}
        //[Route("api /[controller]")]
        //[HttpGet("{fnavn}")]
        //public async Task<ActionResult<Genre>> GetGenreNavn2([FromRoute]string fnavn)
        //{
        //    string s = "hans";

        //    return null;
        //}

        //[HttpGet("ordered")]
        //[HttpGet("Name/{name}")]

        //public async Task<ActionResult<Genre>> GetGenre(int id)
        //{
        //    var genre = await _context.Genre.FindAsync(id);

        //    if (genre == null)
        //    {
        //        return NotFound();
        //    }

        //    return genre;
        //}

        // PUT: api/Genres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // update en record / række i en tabel
        // put opdaterer hele objektet
        // patch opdaterer dele af et objekt

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGenre(int id, Genre genre)
        //{
        //    if (id != genre.genreId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(genre).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GenreExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // create ny record / række i tabel
        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.genreId }, genre);
        }

        // DELETE: api/Genres/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
        {
            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        private bool GenreExists(int id)
        {
            return _context.Genre.Any(e => e.genreId == id);
        }
    }
}
