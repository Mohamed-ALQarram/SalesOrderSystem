using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Order_Classes;

namespace DAL.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ProductId)
                .IsRequired(true);

            builder.Property(x => x.SalePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder.ToTable("OrderItems");
        }
    }

}
