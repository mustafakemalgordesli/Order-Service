using Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistence.Repository;

public class CarrierConfigurationRepository : GenericRepository<CarrierConfiguration>, ICarrierConfigurationRepository
{
    public CarrierConfigurationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public CarrierConfiguration FindByDesi(int desi)
    {
        return dbContext.Set<CarrierConfiguration>().Where(x => x.CarrierMinDesi <= desi && x.CarrierMaxDesi >= desi && x.Carrier.CarrierIsActive == true).OrderBy(x => x.CarrierCost).ToList().FirstOrDefault();
    }

    public CarrierConfiguration FindByDesiMostSuit(int desi)
    {
        return dbContext.Set<CarrierConfiguration>().Where(x => x.CarrierMaxDesi <= desi && x.Carrier.CarrierIsActive == true).OrderBy(x => Convert.ToDecimal(x.Carrier.CarrierPlusDesiCost * (desi - x.CarrierMaxDesi)) + x.CarrierCost).Include(x => x.Carrier).FirstOrDefault();
    }
}
