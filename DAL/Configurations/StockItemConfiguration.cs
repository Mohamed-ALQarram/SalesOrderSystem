using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Order_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x=> x.Stock).WithMany(x => x.StockItems).HasForeignKey(x=>x.StockId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product).WithMany(x => x.StockItems).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("StockItems");
        }
    }
}
