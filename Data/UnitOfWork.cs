﻿using FormulaAPI.Core;
using FormulaAPI.Core.Repositories;

namespace FormulaAPI.Data;

public class UnitOfWork : IUnityOfWork, IDisposable
{
    private readonly ApiDbContext _context;


    public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");

        Drivers = new DriverRepository(_context, logger);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public IDriverRepository Drivers { get; }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}