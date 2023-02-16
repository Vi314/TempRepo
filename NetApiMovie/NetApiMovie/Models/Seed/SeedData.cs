using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using NetApiMovie.Models.Context;

namespace NetApiMovie.Models.Seed
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {

            //Using blğunu middleware'de servis dışında kalmamak için kullanıyoruz. Middleware yapısı sadece singleton yapıları desteklemektedir. Servis yapısını seed classı içerisinde kullanmaj için  using bloğuna ihtiyacımız bulunmaktadır.
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<MovieDbContext>();

                context.Database.Migrate();

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(
                        new Movie { Title = "Life Of Pi", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Genre = "Adventure", Rank = 80 },
                         new Movie { Title = "The Matrix", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Genre = "Sci-fi", Rank = 85 },
                          new Movie { Title = "The Godfather", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Genre = "Adventure", Rank = 90 }
                        );

                }

                context.SaveChanges();

            }
        }
    }
}
