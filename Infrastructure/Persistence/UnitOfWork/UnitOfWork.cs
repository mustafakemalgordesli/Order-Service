using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Persistence.Context;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork;

public class UnitofWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    private readonly Lazy<ICarrierRepository> _carriers;
    private readonly Lazy<ICarrierConfigurationRepository> _carriersConfiguration;
    private readonly Lazy<ICarrierReportRepository> _carriersReportRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;
    public UnitofWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _carriers = new Lazy<ICarrierRepository>(() => new CarrierRepository(_dbContext));
        _carriersConfiguration = new Lazy<ICarrierConfigurationRepository>(() => new CarrierConfigurationRepository(_dbContext));
        _carriersReportRepository = new Lazy<ICarrierReportRepository>(() => new CarrierReportRepository(_dbContext));
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_dbContext));
    }

    public ICarrierRepository CarrierRepository => _carriers.Value;
    public ICarrierConfigurationRepository CarrierConfigurationRepository => _carriersConfiguration.Value;
    public ICarrierReportRepository CarrierReportRepository => _carriersReportRepository.Value;
    public IOrderRepository OrderRepository => _orderRepository.Value;



    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}