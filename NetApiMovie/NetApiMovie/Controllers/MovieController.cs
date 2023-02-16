using Microsoft.AspNetCore.Mvc;
using NetApiMovie.Models;
using NetApiMovie.Models.Context;
using NetApiMovie.Service.Interface;
using System.Linq;

namespace NetApiMovie.Controllers
{


    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext context;
        private readonly IMovieService movieService;

        public MovieController(MovieDbContext context,
                               IMovieService movieService
                             )
        {
            this.context = context;
            this.movieService = movieService;
        }

        //GET
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = movieService.GetMovies();

            if (movies == null)
            {
                return NotFound("filmler bulunamadı");
            }
            else
            {
                return Ok(movies);
            }
        }


        //POST
        [HttpPost]
        public IActionResult PostMovie(Movie movie)
        {
            var state = movieService.CreateMovie(movie);

            if (state == Models.Enum.MovieStatusCodes.Ok)
            {
                return Ok(movie);
            }
            else
            {
                return BadRequest();
            }
        }
        //PUT
        [HttpPut]
        public IActionResult PutMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var state = movieService.UpdateMovie(movie);
                if (state == Models.Enum.MovieStatusCodes.Ok)
                {
                    return Ok(movie);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //DELETE
        public IActionResult DeleteMovie(int id)
        {
            var state = movieService.DeleteMovie(id);

            if (state == Models.Enum.MovieStatusCodes.Ok)
            {
                return Ok("Silindi");
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
