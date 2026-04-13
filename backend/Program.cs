// created:    20260409 / alphabeit
// lastupdate: 20260413 / alphabeit

// ref on https://www.csharptutorial.net/entity-framework-core-tutorial/

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // sql connection string



namespace Backend;

public class BackendContext: DbContext
{
    public DbSet<VehicleBody> VehicleBodys { get; set;}
    public DbSet<VehicleColor> VehicleColors {  get; set; }
    public DbSet<Wheel> Wheels {  get; set; }
    public DbSet<Engine> Engines {  get; set; }
    public DbSet<Order> Orders {  get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("database");

        optionsBuilder.UseSqlServer(connectionString);
    }
}



// Tables, DB structure

public class VehicleBody  
{
    public int Id { get; set; }
    public required string Name { get; set; }
    //public required img Image { get; set; }
    public required float Price { get; set; }
};

public class VehicleColor 
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string HexCode { get; set; }
    public required float Price { get; set; }
};

public class Wheel      
{
    public int Id { get; set; }
    public required string Name { get; set; }
    //public required img Image { get; set; }
    public required float Price { get; set; }
};

public class Engine       
{
    public int Id { get; set; }
    public required string Name { get; set; }
    //public required img Image { get; set; }
    public required float PS { get; set; }
    public required float Price { get; set; }
};

public class Order        
{
    public int Id { get; set; }
    public required DateTime OrderDate { get; set; }
    public required VehicleBody VehicleBody { get; set; }
    public required VehicleColor VehicleColor { get; set; }
    public required Wheel Wheel { get; set; }
    public required Engine Engine { get; set; }
};



// default data for database

public class DataInjection
{
    public static void Main()
    {
        // database object
        var context = new BackendContext();

        // In case, VehicleBodys is empty.
        if (!context.VehicleBodys.Any()) 
        {
            var vehiclebodys = new List<VehicleBody>()
            {
                new VehicleBody { Name="Typ A", Price=1249.39f },
                new VehicleBody { Name="Typ B", Price=1447.29f },
                new VehicleBody { Name="Typ C", Price=1809.19f }
            };
        
            foreach (var vehiclebody in vehiclebodys)
            {
                context.VehicleBodys.Add(vehiclebody);
            };
        };

        // In case, VehicleColors is empty.
        if (!context.VehicleColors.Any()) 
        {
            var vehiclecolors = new List<VehicleColor>()
            {
                new VehicleColor { Name="Firebrick", HexCode="#B22222", Price=449.32f },
                new VehicleColor { Name="Aqua", HexCode="#00FFFF", Price=248.27f },
                new VehicleColor { Name="Limegreen", HexCode="#32CD32", Price=199.87f },
            };
        
            foreach (var vehiclecolor in vehiclecolors)
            {
                context.VehicleColors.Add(vehiclecolor);
            };
        };

        // In case, Wheels is empty.
        if (!context.Wheels.Any()) 
        {
            var wheels = new List<Wheel>()
            {
                new Wheel { Name="Typ A", Price=137.39f },
                new Wheel { Name="Typ B", Price=116.74f },
                new Wheel { Name="Typ C", Price=219.88f },
            };

            foreach (var wheel in wheels)
            {
                context.Wheels.Add(wheel);
            };
        };

        // In case, Engines is empty.
        if (!context.Engines.Any()) 
        {
            var engines = new List<Engine>()
            {
                new Engine { Name="Typ A", PS=22.4f, Price=2584.91f },
                new Engine { Name="Typ B", PS=34.8f, Price=3592.42f },
                new Engine { Name="Typ C", PS=61.0f, Price=6781.27f },
            };

            foreach (var engine in engines)
            {
                context.Engines.Add(engine);
            };
        }

        // Write content to tables
        context.SaveChanges();
    }

};
