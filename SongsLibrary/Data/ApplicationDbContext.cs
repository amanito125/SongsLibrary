using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SongsLibrary.Data;

namespace SongsLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SongsLibrary.Data.Genre>? Genre { get; set; }
        public DbSet<SongsLibrary.Data.Artist>? Artist { get; set; }
        public DbSet<SongsLibrary.Data.MusicVideo>? MusicVideo { get; set; }
    }
}
