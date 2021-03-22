using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema2021001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MoviesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/Movies/genrestring
        [HttpGet("genrestring")]
        public string GetGenreString()
        {
            return "hej med dig";
            //return await _context.Movie.ToListAsync();
        }
        // GET: api/Movies/genre
        [HttpGet("genre")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetGenre()
        {
            //var joinM3 = studentsList.Join(addressList,
            //                              std => std.addressId,
            //                              adr => adr.id,
            //                              (std, adr) => new { std, adr })
            //                              .Join(marksList,
            //                              students => students.std.id,
            //                              marks => marks.studentId,
            //                              (students, marks) => new { students, marks })
            //                              .Select(samlet => new
            //                              {
            //                                  studentName = samlet.students.std.name,
            //                                  adr = samlet.students.adr.address,
            //                                  mark = samlet.marks.grade
            //                              })
            //                              //Where()
            //                              .ToList();
            var joinMG = await _context.Movie
                          .Join(_context.Genre,
                          movie => movie.movieId,
                          Genre => Genre.genreId,
                          (movie, Genre) => new { movie, Genre })
                          .Join(_context.Genre,
                          Genre => Genre.Genre.genreId,
                          genre => genre.genreId,
                          (Genre, genre) => new { Genre, genre })
                          .Select(samlet => new // alternativet er en MVVM eller en class, eks: samlet => new Movie
                          {
                              title = samlet.Genre.movie.title,
                              genreName = samlet.genre.genreName,
                              samlet.Genre.movie.movieId
                          }
                          ).ToListAsync();
            // MWWM
            return Ok(joinMG); // magisk convert....
        }


        // GET: api/Movies/genre   bliver en uendelig løkke i deres udtræk
        [HttpGet("genre2")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetGenre2()
        {
            var joinMG = await _context.Movie
                          .Join(_context.Genre,
                          movie => movie.movieId,
                          Genre => Genre.genreId,
                          (movie, Genre) => new { movie, Genre })
                          .Join(_context.Genre,
                          Genre => Genre.Genre.genreId,
                          genre => genre.genreId,
                          (Genre, genre) => new { Genre, genre })
                          //.Select(samlet => new // alternativet er en MVVM eller en class, eks: samlet => new Movie
                          //{
                          //    title = samlet.Genre.movie.title,
                          //    genrename = samlet.genre.genrename,
                          //    samlet.Genre.movie.movieId
                          //}
                          .ToListAsync();
            // MWWM
            return Ok(joinMG); // magisk convert....
        }


        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.movieId)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.movieId }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.movieId == id);
        }
    }
}
