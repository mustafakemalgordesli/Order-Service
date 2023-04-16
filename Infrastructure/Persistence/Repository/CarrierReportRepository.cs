using Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository;

public class CarrierReportRepository : GenericRepository<CarrierReport>, ICarrierReportRepository
{
    public CarrierReportRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddRangeAsync(List<CarrierReport> carrierReports)
    {
        await dbContext.Set<CarrierReport>().AddRangeAsync(carrierReports);
    }
}
