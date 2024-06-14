using Microsoft.EntityFrameworkCore;

namespace Bide_API.Models;

public class UserDbContext: DbContext {
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options){
        
    }
    
    public DbSet<User> User { get; set; }
}