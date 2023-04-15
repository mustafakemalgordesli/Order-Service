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

public class CarrierConfigurationEntityConfiguration : BaseEntityConfiguration<CarrierConfiguration>
{
    public override void Configure(EntityTypeBuilder<CarrierConfiguration> builder)
    {
        base.Configure(builder);

        builder.ToTable("carrierconfigurations", ApplicationDbContext.DEFAULT_SCHEMA);

        builder.Property(x => x.CarrierId).IsRequired();
        builder.Property(x => x.CarrierMinDesi).IsRequired();
        builder.Property(x => x.CarrierMaxDesi).IsRequired();
        builder.Property(x => x.CarrierCost).IsRequired();

        builder
            .HasOne(o => o.Carrier)
            .WithMany(c => c.CarrierConfigurations)
            .HasForeignKey(o => o.CarrierId);
    }
}
