using Example.WebApi.Models;
using Example.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{


    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> GetAll()
    {
        return VehicleService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Vehicle> Get(int id)
    {
        var vehicle = VehicleService.Get(id);

        if (vehicle == default)
        {
            return NotFound();
        }
        return vehicle;
    }

    [HttpPost]
    public ActionResult Insert(Vehicle vehicle)
    {
        VehicleService.Add(vehicle);

        return CreatedAtAction(nameof(Insert), new { id = vehicle.Id }, vehicle);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var vehicle = VehicleService.Get(id);

        if (vehicle == default)
        {
            return NotFound();
        }

        VehicleService.Delete(id);

        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Vehicle vehicle)
    {
        if (id != vehicle.Id)
        {
            return BadRequest();
        }

        var existingVehicle = VehicleService.Get(id);

        if (existingVehicle == null)
        {
            return NotFound();

        }

        VehicleService.Update(vehicle);

        return NoContent();

    }
}
