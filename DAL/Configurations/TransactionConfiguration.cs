using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Payments_Classes;

namespace DAL.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.TransactionId);

            builder.HasMany(x => x.Payments);

            builder.HasOne(x => x.Order).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Transactions");
        }
    }

}
