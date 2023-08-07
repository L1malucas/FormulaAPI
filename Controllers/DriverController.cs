using FormulaAPI.Core;
using FormulaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly IUnityOfWork _unityOfWork;

    public DriversController(IUnityOfWork unitOfWork)
    {
        _unityOfWork = unitOfWork;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unityOfWork.Drivers.All());
    }

    [HttpGet]
    [Route("getId")]
    public async Task<IActionResult> GetId(int id)
    {
        var driver = await _unityOfWork.Drivers.GetId(id);

        if (driver == null) return NotFound();
        return Ok(driver);
    }

    [HttpPost]
    [Route("addDriver")]
    public async Task<IActionResult> AddDriver(Driver driver)
    {
        await _unityOfWork.Drivers.Add(driver);
        await _unityOfWork.CompleteAsync();
        return Ok(driver);
    }

    [HttpPut]
    [Route("updateDriver")]
    public async Task<IActionResult> UpdateDriver(Driver driver)
    {
        var existDriver = await _unityOfWork.Drivers.GetId(driver.Id);

        await _unityOfWork.Drivers.Update(driver);
        await _unityOfWork.CompleteAsync();
        return NoContent();
    }

    [HttpDelete]
    [Route("deleteDriver")]
    public async Task<IActionResult> DeleteDriver(int id)

    {
        var driver = await _unityOfWork.Drivers.GetId(id);

        if (driver == null) return NotFound();

        await _unityOfWork.Drivers.Delete(driver);
        await _unityOfWork.CompleteAsync();
        return NoContent();
    }
}