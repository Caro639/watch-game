using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WatchGame.Data;
using System;
using System.Linq;

namespace WatchGame.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new WatchGameContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<WatchGameContext>>()))
        {
            // Look for any games.
            if (context.Game.Any())
            {
                return;   // DB has been seeded
            }
            context.Game.AddRange(
                new Game
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Horror",
                    Price = 7.99M
                },
                new Game
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },
                new Game
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },
                new Game
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Action",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}