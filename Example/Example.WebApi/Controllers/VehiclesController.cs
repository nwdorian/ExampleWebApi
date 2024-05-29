﻿using Microsoft.AspNetCore.Mvc;

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
        var vehicle = _vehicles.SingleOrDefault(x => x.Id == id);

        if (vehicle == default)
        {
            return NotFound();
        }
        return vehicle;
    }

    [HttpPost]
    public ActionResult<Vehicle> Insert(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);

        return vehicle;
    }
}
