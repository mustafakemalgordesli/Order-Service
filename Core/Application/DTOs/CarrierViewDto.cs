using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;

public class CarrierViewDto
{
    public int Id { get; set; }
    public string CarrierName { get; set; }
    public bool CarrierIsActive { get; set; }
    public int CarrierPlusDesiCost { get; set; }
}
