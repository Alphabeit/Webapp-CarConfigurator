// created:    20260415 / alphabeit
// lastupdate: 20260415 / alphabeit

// ========================================================
// Tables 
// ========================================================
// Define Objects, use them later as tables with EFCore. 

// See also as ref https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 (Step 2)
// See also as ref https://github.com/kakashidota/ProductAPI/blob/master/ProductAPI/Models/Product.cs

namespace Backend.Models
{
    // used data tables to store data
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


    // api return object
    // See also as ref https://medium.com/@e.talal/build-apis-in-net-core-with-entity-framework-bb76a7ba3d40 (Secound step 5)
    public class ResultOfAction<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
