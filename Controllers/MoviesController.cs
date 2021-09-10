using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies;
using Movies.Data;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesContext _context;

        public MoviesController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        [Route("api/Movies/{id}")]
        public async Task<ActionResult<IEnumerable<MovieDetails>>> GetMovieByID(int id)
        {
            List<MovieDetails> movieDetails = new List<MovieDetails>();
            try
            {
                var movie = await _context.Movie.FindAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }
                MovieDetails details = new MovieDetails();
                var stills = await getMovieStills(id);
                details.stills = stills.Value.ToList();
                PropertyInfo[] detailsprops = details.GetType().GetProperties();
                PropertyInfo[] moviesprops = movie.GetType().GetProperties();
                foreach (var prop in moviesprops)
                {
                    var detailprop = detailsprops.FirstOrDefault(x => x.Name == prop.Name);
                    detailprop.SetValue(details, prop.GetValue(movie));
                }
                movieDetails.Add(details);
                return movieDetails;
            }
            catch (Exception ex)
            {
                
                return NotFound();
            }
        }
        private async Task<ActionResult<IEnumerable<Movie_Stills>>> getMovieStills(int id)
        {
            List<Movie_Stills> stills = new List<Movie_Stills>();
            List<MovieStills> moviestills = null;
            moviestills = await _context.MovieStills.Where(x => x.MovieId == id).ToListAsync();
            if (moviestills == null)
            {
                return NotFound();
            }
            foreach (var moviestill in moviestills)
            {
                Movie_Stills still = new Movie_Stills();
                still.Id = moviestill.Id;
                still.MovieId = moviestill.MovieId;
                still.StillURL = _context.Stills.FirstOrDefault(x => x.Id == moviestill.StillId).stillURL;
                stills.Add(still);
            }
            return stills;
        }
        // GET: api/MoivesSearch/title/val
        [HttpGet("{ParamType},{val}")]
        [Route("api/Moives/{paramtype}/{paramval}")]
        public async Task<ActionResult<IEnumerable<Movie>>> SearchMovie(string ParamType, string val)
        {
            List<Movie> movie = null;
            if (ParamType == "Title")
                movie = await _context.Movie.Where(x => x.Title.Contains(val)).ToListAsync();
            else if (ParamType == "Location")
                movie = await _context.Movie.Where(x => x.Location.Contains(val)).ToListAsync();
            else if (ParamType == "Language")
                movie = await _context.Movie.Where(x => x.Language.Contains(val)).ToListAsync();

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
            if (id != movie.Id)
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

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
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
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
