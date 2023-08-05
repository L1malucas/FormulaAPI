using FormulaAPI.Data;
using FormulaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly ApiDbContext _context;

    public DriversController(ApiDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Drivers.ToListAsync());
    }

    [HttpGet]
    [Route("getId")]
    public async Task<IActionResult> GetId(int id)
    {
        var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

        if (driver == null) return NotFound(); 
        return Ok(driver);
    }

    [HttpPost]
    [Route("addDriver")]
    public async Task<IActionResult> AddDriver(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
        return Ok(driver); 
    }
    
    [HttpPut]
    [Route("updateDriver")]
    public async Task<IActionResult> UpdateDriver(Driver driver)
    {
        var existDriver =await _context.Drivers.FirstOrDefaultAsync(x => x.Id == driver.Id);

        if (existDriver == null) return NotFound();

        existDriver.Name = driver.Name;
        existDriver.Team = driver.Team;
        existDriver.DriverNumber = driver.DriverNumber;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpDelete]
    [Route("deleteDriver")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var driver =await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

        if (driver == null) return NotFound();

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
