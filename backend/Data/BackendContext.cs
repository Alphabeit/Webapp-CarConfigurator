// created:    20260415 / alphabeit
// lastupdate: 20260415 / alphabeit

// ========================================================
// Database 
// ========================================================
// Define Objects, use them later as tables with EFCore. 

// See also https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 (Step 3)
// See also https://github.com/kakashidota/ProductAPI/blob/master/ProductAPI/Data/ProductContext.cs

using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class BackendContext : DbContext
    {
        public BackendContext(DbContextOptions<BackendContext> options) 
            : base(options) { }

        public DbSet<VehicleBody> VehicleBodys { get; set;}
        public DbSet<VehicleColor> VehicleColors {  get; set; }
        public DbSet<Wheel> Wheels {  get; set; }
        public DbSet<Engine> Engines {  get; set; }
        public DbSet<Order> Orders {  get; set; }
    };
}
