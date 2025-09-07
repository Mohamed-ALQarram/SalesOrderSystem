using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.Order_Classes;

namespace DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductId)
                .ValueGeneratedNever()
                .IsRequired(true);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder.Property(x => x.ProductName).HasColumnType("varchar").HasMaxLength(25)
                .IsRequired(false);

            builder.Property(x => x.Type)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired(true);



            builder.ToTable("Products");
        }
    }

}
