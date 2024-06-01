using Example.WebApi.Models;

namespace Example.WebApi.Services;

public static class VehicleService
{
    private static List<Vehicle> Vehicles { get; }

    private static int NextId = 3;

    static VehicleService()
    {
        Vehicles = new List<Vehicle>
        {
        new Vehicle { Id = 1, Manufacturer = "Bmw", Model = "530", Color = "Black", HorsePower = 250},
        new Vehicle { Id = 2, Manufacturer = "Mercedes", Model = "GLA", Color = "Grey", HorsePower = 200},
        new Vehicle { Id = 3, Manufacturer = "Toyota", Model = "Yaris", Color = "Red", HorsePower = 80},
        new Vehicle { Id = 4, Manufacturer = "Volkswagen", Model = "Golf", Color = "White", HorsePower = 110}
        };
    }

    public static List<Vehicle> GetAll()
    {
        return Vehicles;
    }

    public static Vehicle? Get(int id)
    {
        var vehicle = Vehicles.FirstOrDefault(v => id == v.Id);
        return vehicle;
    }

    public static void Add(Vehicle vehicle)
    {
        vehicle.Id = NextId++;
        Vehicles.Add(vehicle);
    }

    public static void Delete(int id)
    {
        var vehicle = Vehicles.FirstOrDefault(v => id == v.Id);
        if (vehicle == null)
        {
            return;
        }

        Vehicles.Remove(vehicle);
    }

    public static void Update(Vehicle vehicle)
    {
        var index = Vehicles.FindIndex(v => v.Id == vehicle.Id);
        if (index == -1)
        {
            return;
        }

        Vehicles[index] = vehicle;
    }
}
