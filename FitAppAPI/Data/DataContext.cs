using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FitAppAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<User> Users => Set<User>();

       

    }
}
