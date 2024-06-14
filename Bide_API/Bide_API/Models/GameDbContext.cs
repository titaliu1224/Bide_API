using Microsoft.EntityFrameworkCore;

namespace Bide_API.Models;

public class GameDbContext: DbContext {
    public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options) {
        
    }
    
    public DbSet<Game> Game { get; set; }
}