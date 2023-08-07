using FormulaAPI.Data;
using FormulaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaAPI.Core.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger) {}

    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            var drivers = await Context.Drivers.Where(x => x.Id < 100).ToListAsync();
            return drivers;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<Driver?> GetDriverId(int driverNumber)
    {
        try
        {
            return await Context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == driverNumber);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}