using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.Payments_Classes;

namespace DAL.Configurations
{
    public class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.Property(x => x.CardNo)
                .HasColumnType("varchar")
                .HasMaxLength(16)
                .IsRequired(true);

                builder.Property(x => x.ExpiredDate)
                .HasColumnType("date")
                .IsRequired(true);

            builder.Property(x => x.Type)
                .HasConversion<string>()
                .HasMaxLength(15)
                .IsRequired(true);

        }
    }

}
