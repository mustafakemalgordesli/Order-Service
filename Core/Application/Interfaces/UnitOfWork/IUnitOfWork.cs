using Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    void SaveChanges();
    Task SaveChangesAsync();
    ICarrierRepository CarrierRepository { get; }
    ICarrierReportRepository CarrierReportRepository { get; }
    IOrderRepository OrderRepository { get; }
    ICarrierConfigurationRepository CarrierConfigurationRepository { get; }
}
