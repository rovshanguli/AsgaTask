using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(m => m.StartTime).IsRequired();
            builder.Property(m => m.CityId).IsRequired();
            builder.Property(m => m.EndTime).IsRequired();
            builder.Property(m => m.Cash).IsRequired();
           
        }
    }
}
