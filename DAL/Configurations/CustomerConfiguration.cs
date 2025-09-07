using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Customer_Classes;

namespace DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);

            builder.HasMany(x => x.Orders).WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.Property(x => x.phone).HasColumnType("nvarchar").HasMaxLength(15)
                .IsRequired(true);

            builder.HasDiscriminator<string>("Type").HasValue<Person>("Person").HasValue<Company>("Company");
            builder.Property("Type").HasColumnType("varchar").HasMaxLength(8)
                .IsRequired(true);
            builder.ToTable("Customers");
            //default
            builder.UseTphMappingStrategy();


        }
    }
}

