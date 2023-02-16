using NetApiMovie.Models;
using NetApiMovie.Models.Context;
using NetApiMovie.Models.Enum;
using NetApiMovie.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NetApiMovie.Service.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext context;

        public MovieService(MovieDbContext context)
        {
            this.context = context;
        }

        public MovieStatusCodes CreateMovie(Movie movie)
        {
            context.Movies.Add(movie);
            if (context.SaveChanges() > 0)
            {
                return MovieStatusCodes.Ok;
            }
            else
            {
                return MovieStatusCodes.BadRequest;
            }
        }

        public MovieStatusCodes DeleteMovie(int id)
        {
            var deleted = GetMovieById(id);
            if (deleted != null)
            {
                context.Movies.Remove(deleted);
                context.SaveChanges();
                return MovieStatusCodes.Ok;
            }
            else
            {
                return MovieStatusCodes.NotFound;
            }
        }

        public Movie GetMovieById(int id)
        {
            var deleted = context.Movies.Find(id);
            return deleted;
        }

        public List<Movie> GetMovies()
        {
            return context.Movies.ToList();
        }

        //Todo: Implement Search
        public List<Movie> SearchMovies(string value)
        {
            throw new System.NotImplementedException();
        }

        public MovieStatusCodes UpdateMovie(Movie movie)
        {
            var updated = context.Movies.FirstOrDefault(x => x.Id == movie.Id);
            if (updated == null)
            {
                return MovieStatusCodes.NotFound;
            }
            else
            {
                updated.Title = movie.Title;
                updated.Description = movie.Description;
                updated.Rank = movie.Rank;
                updated.Genre = movie.Genre;
                if (context.SaveChanges() > 0)
                {
                    return MovieStatusCodes.Ok;
                }
                else
                {
                    return MovieStatusCodes.BadRequest;
                }
            }
        }

    }
}
