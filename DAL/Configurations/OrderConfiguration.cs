using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Order_Classes;
using Models.Enums;


namespace DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);

            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            builder.Property(x => x.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);
            builder.Property(x => x.OrderStatus)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired(true);


            builder.ToTable("Orders");
        }
    }

}
