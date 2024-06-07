using MemeLib.DbContext.Models;
using Microsoft.EntityFrameworkCore;

namespace MemeLib.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<MemeDbModel> Memes { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}