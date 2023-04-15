using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Carrier : BaseEntity
{
    public string CarrierName { get; set; }
    public bool CarrierIsActive { get; set; } = true;
    public int CarrierPlusDesiCost { get; set; }
    public virtual ICollection<CarrierConfiguration>? CarrierConfigurations { get; set; }
    public virtual ICollection<CarrierReport>? CarrierReports { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}
