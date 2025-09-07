using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Order_Classes;

namespace DAL.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(x => x.StockId);
            builder.Property(x => x.StockId)
                .ValueGeneratedNever();

            builder.ToTable("Stocks");
        }
    }

}
