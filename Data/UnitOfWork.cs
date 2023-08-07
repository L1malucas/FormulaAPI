using FormulaAPI.Core;
using FormulaAPI.Core.Repositories;

namespace FormulaAPI.Data;

public class UnitOfWork : IUnityOfWork, IDisposable
{
    private readonly ApiDbContext _context;

    private readonly ILogger _logger;

    public UnitOfWork(ApiDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;

        Drivers = new DriverRepository(_context, logger);
    }
    public IDriverRepository Drivers { get; }

    public void Dispose()
    {
        _context.Dispose();
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}