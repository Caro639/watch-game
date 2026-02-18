using Microsoft.EntityFrameworkCore;
using WatchGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchGame.Data;

public class WatchGameContext : DbContext
{
    public WatchGameContext(DbContextOptions<WatchGameContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Game { get; set; } = default!;
}
