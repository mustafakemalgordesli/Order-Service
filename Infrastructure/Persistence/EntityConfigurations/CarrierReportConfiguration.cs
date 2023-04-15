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

internal class CarrierReportConfiguration : BaseEntityConfiguration<CarrierReport>
{
    public override void Configure(EntityTypeBuilder<CarrierReport> builder)
    {
        base.Configure(builder);

        builder.ToTable("carrierreports", ApplicationDbContext.DEFAULT_SCHEMA);

        builder.Property(x => x.CarrierId).IsRequired();
        builder.Property(x => x.CarrierCost).IsRequired();
        builder.Property(x => x.CarrierReportDate).IsRequired();

        builder
            .HasOne(o => o.Carrier)
            .WithMany(c => c.CarrierReports)
            .HasForeignKey(o => o.CarrierId);
    }
}
