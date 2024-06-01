using Example.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private static readonly List<Vehicle> _vehicles = new List<Vehicle>
    {
        new Vehicle { Id = 1, Manufacturer = "Bmw", Model = "530", Color = "Black", HorsePower = 250},
        new Vehicle { Id = 2, Manufacturer = "Mercedes", Model = "GLA", Color = "Grey", HorsePower = 200},
        new Vehicle { Id = 3, Manufacturer = "Toyota", Model = "Yaris", Color = "Red", HorsePower = 80},
        new Vehicle { Id = 4, Manufacturer = "Volkswagen", Model = "Golf", Color = "White", HorsePower = 110}
    };

    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> GetAll()
    {
        return _vehicles;
    }

    [HttpGet("{id}")]
    public ActionResult<Vehicle> Get(int id)
    {
        var vehicle = _vehicles.FirstOrDefault(x => x.Id == id);

        if (vehicle == default)
        {
            return NotFound();
        }
        return vehicle;
    }

    [HttpPost]
    public ActionResult Insert(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);

        return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var vehicle = _vehicles.FirstOrDefault(x => x.Id == id);

        if (vehicle == default)
        {
            return NotFound();
        }

        _vehicles.RemoveAt(id);

        return NoContent();
    }

    [HttpPut]
    public ActionResult Update(int id, Vehicle vehicle)
    {
        if (id != vehicle.Id)
        {
            return BadRequest();
        }

        var existingVehicle = _vehicles.FirstOrDefault(x => x.Id == id);

        if (existingVehicle != default)
        {
            existingVehicle.Manufacturer = vehicle.Manufacturer;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Color = vehicle.Color;
            existingVehicle.HorsePower = vehicle.HorsePower;
        }
        else
        {
            return NotFound();
        }

        return NoContent();

    }
}
