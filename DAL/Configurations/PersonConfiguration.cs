using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Customer_Classes;

namespace DAL.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.Property(x=>x.FullName).HasColumnType("varchar").HasMaxLength(40)
                .IsRequired(false);
            builder.Property(x => x.BillingAddress).HasColumnType("varchar").HasMaxLength(100)
                .IsRequired(true);
        }
    }
}

