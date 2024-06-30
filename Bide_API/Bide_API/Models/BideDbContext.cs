using Microsoft.EntityFrameworkCore;

namespace Bide_API.Models;

public class BideDbContext {
    public BideDbContext(DbContextOptions options) {
        
    }

    public DbSet<Game> Game { get; set; } = null;
    public DbSet<User> User { get; set; } = null;
}