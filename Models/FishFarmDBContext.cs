using Microsoft.EntityFrameworkCore;

namespace FishFarm.Models
{
    public class FishFarmDBContext : DbContext
    {
        public FishFarmDBContext(DbContextOptions<FishFarmDBContext> options ) : base( options ) 
        {
            
        }
        public DbSet<FishFarms> FishFarms { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Boats> Boats { get; set; }
    }
}
