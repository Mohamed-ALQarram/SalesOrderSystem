using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Payments_Classes;

namespace DAL.Configurations
{
    public class CheckConfiguration : IEntityTypeConfiguration<Check>
    {
        public void Configure(EntityTypeBuilder<Check> builder)
        {
            builder.Property(x => x.BankName)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired(true);
            builder.Property(x => x.BankID)
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .IsRequired(true);

        }
    }

}
