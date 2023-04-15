using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class CarrierReport : BaseEntity
{
    public int CarrierId { get; set; }
    public decimal CarrierCost { get; set; }
    public DateTime CarrierReportDate { get; set; }
    public virtual Carrier Carrier { get; set; }
}
