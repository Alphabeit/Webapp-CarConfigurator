// created:    20260409 / alphabeit
// lastupdate: 20260415 / alphabeit

// See also as ref https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 
// See also as ref https://github.com/kakashidota/ProductAPI

// open libaries
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // sql connection string
using Microsoft.AspNetCore.Mvc;

// own objects
using Backend.Data;
using Backend.Models;
using Backend.Controllers;
using Backend.Services;






// ========================================================
// Default Data 
// ========================================================
// The Data, who used by the web-application.
// Get injected right while starting.

namespace Backend
{
    public class Program
    {
        // inject default data (when not already exists)
        public static void InjectionDefaultData(BackendContext context)
        {

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



        // Run program.
        // Build database, inject data.
        // Maps API controller.

        // See also as ref https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 
        // See also as ref https://github.com/kakashidota/ProductAPI/blob/master/ProductAPI/Program.cs

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BackendContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("database")));

            // Register Service
            // See also as ref https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 (Secound step 3)
            builder.Services.AddScoped<IBackendService, BackendService>();

            // Add Api Controller
            // See also as ref https://www.zetcode.com/asp-net/addcontrollers/
            builder.Services.AddControllers();

            var app = builder.Build();

            // create database
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<BackendContext>();
                context.Database.Migrate();

                // inject default data
                InjectionDefaultData(context);
            }

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}





// ========================================================
// API Controller 
// ========================================================
// Offers REST Api for frontent.

// See also as ref https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 (step 7)

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BackendController : ControllerBase
    {
        // ensure privacy
        private readonly IBackendService _backendService;
        public BackendController(IBackendService backendService)
        {
            _backendService = backendService;
        }

        // Get data from table.
        [HttpGet("{table}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTableByName(string table)
        {
            var result = await _backendService.GetTableByNameAsync(table);
            return Ok(result);
        }

    }
}




// ========================================================
// Interface 
// ========================================================
// See also as ref https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 (Secound Step 1)

namespace Backend.Services
{
    public interface IBackendService
    {
        Task<ResultOfAction<object>> GetTableByNameAsync(string table);
    }
}





// ========================================================
// Api Functions 
// ========================================================
// Functions, who get executed, when API get used.

// See also as ref https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 (Secound Step 2)

namespace Backend.Services
{
    public class BackendService : IBackendService
    {
        // ensure privacy
        private readonly BackendContext _context;
        public BackendService(BackendContext context)
        {
            _context = context;
        }

        public async Task<ResultOfAction<object>> GetTableByNameAsync(string table)
        {
            // return table with same name as string
            object result = table.ToLower() switch
            {
                "vehiclebodys" => await _context.VehicleBodys.ToListAsync(),
                "vehiclecolors" => await _context.VehicleColors.ToListAsync(),
                "wheels" => await _context.Wheels.ToListAsync(),
                "engines" => await _context.Engines.ToListAsync(),
                _ => String.Empty
            };

            // case, return object is empty
            if (result == null)
            {
                return new ResultOfAction<object> {Success = false, Message = "Table not found.", Data = String.Empty};
            }
            
            // case, return object contains data
            return new ResultOfAction<object> {Success = true, Message = "Table fetched successfully.", Data = result};
        }
    }
}
