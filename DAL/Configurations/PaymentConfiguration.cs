using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Payments_Classes;

namespace DAL.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.PaymentId);

            builder.HasDiscriminator<string>("Type")
                .HasValue<Cash>("Cash")
                .HasValue<Credit>("Credit")
                .HasValue<Check>("Check");

            builder.Property(x => x.Amount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired(true);

            builder.ToTable("Payments");
            //default
            builder.UseTphMappingStrategy();
        }
    }

}
