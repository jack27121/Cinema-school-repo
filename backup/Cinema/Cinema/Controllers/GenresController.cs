using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema2021001.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        // variabel
        // Aggregate (Aggregering)
        private readonly DatabaseContext _context;
        // DI - Dependency Injection (Design Pattern)
        public GenresController(DatabaseContext context)
        {
            //Bil b = new Bil(); //associering
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
            return await _context.Genre.ToListAsync();
        }

        // GET: api/Genres/5
        /*opret 3 metoder af getGenre og find ud af om man kan overloade??
         * eller de skal hedde noget forskelligt?
         * og hvordan tilgår jeg så de forskellige metoder?
         
         */
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _context.Genre.FindAsync(id);

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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.genreId)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // create ny record / række i tabel
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.genreId }, genre);
        }

        // DELETE: api/Genres/5
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
