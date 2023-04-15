using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class OrderEntityConfiguration : BaseEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        builder.ToTable("orders", ApplicationDbContext.DEFAULT_SCHEMA);

        builder.Property(x => x.OrderCarrierCost).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.OrderDesi).IsRequired();
        builder.Property(x => x.OrderDate).IsRequired();
        builder.Property(x => x.CarrierId).IsRequired();

        builder
            .HasOne(o => o.Carrier)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CarrierId);
    }
}
