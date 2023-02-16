using Microsoft.EntityFrameworkCore;

namespace NetApiMovie.Models.Context
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }

        

        public DbSet<Movie> Movies { get; set; }
    }
}
