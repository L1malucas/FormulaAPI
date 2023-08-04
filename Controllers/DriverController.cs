using FormulaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{
    private static List<Driver> _drivers = new List<Driver>()
    {
        new Driver()
        {
            Id = 1,
            Name = "Lewis Hamilton",
            Team = "Mercedes AMG",
            DriverNumber = 63
        },
        new Driver()
        {
            Id = 2,
            Name = "Sebastian Vettel",
            Team = "Austin Martin",
            DriverNumber = 5
        },       
        new Driver()
        {
            Id = 3,
            Name = "Felipe Massa",
            Team = "Ferrari",
            DriverNumber = 99
        }
    };


    [HttpGet]
    public IActionResult  GetAll()
    {
        return Ok(_drivers);
    }

    [HttpGet]
    [Route("getId")]
    public IActionResult GetId(int id)
    {
        return Ok(_drivers.FirstOrDefault(x => x.Id == id));
    }

    [HttpPost]
    [Route("addDriver")]
    public IActionResult AddDriver(Driver driver)
    {
        _drivers.Add(driver);
        return Ok(); 
    }
    
    [HttpPut]
    [Route("updateDriver")]
    public IActionResult UpdateDriver(Driver driver)
    {
        var existDriver = _drivers.FirstOrDefault(x => x.Id == driver.Id);

        if (existDriver == null) return NotFound();

        existDriver.Name = driver.Name;
        existDriver.Team = driver.Team;
        existDriver.DriverNumber = driver.DriverNumber;
        
        return NoContent();
    }
    
    [HttpDelete]
    [Route("deleteDriver")]
    public IActionResult DeleteDriver(int id)
    {
        var driver = _drivers.FirstOrDefault(x => x.Id == id);

        if (driver == null) return NotFound();

        _drivers.Remove(driver);
        return NoContent();
    }
}
