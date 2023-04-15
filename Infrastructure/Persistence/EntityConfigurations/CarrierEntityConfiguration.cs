using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class CarrierEntityConfiguration : BaseEntityConfiguration<Carrier>
{
    public override void Configure(EntityTypeBuilder<Carrier> builder)
    {
        base.Configure(builder);

        builder.ToTable("carriers", ApplicationDbContext.DEFAULT_SCHEMA);

        builder.Property(x => x.CarrierName).IsRequired().HasMaxLength(255);
        builder.Property(x => x.CarrierIsActive).IsRequired();
        builder.Property(x => x.CarrierPlusDesiCost).IsRequired();
    }
}
