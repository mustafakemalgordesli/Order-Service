using Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class CarrierRepository : GenericRepository<Carrier>, ICarrierRepository
    {
        public CarrierRepository(ApplicationDbContext _context) : base(_context) 
        {

        }
     
    }
}
