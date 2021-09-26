using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterNStock.DAL.Configurations
{
    class TypeProductConfig : IEntityTypeConfiguration<TypeProduct>
    {
        public void Configure(EntityTypeBuilder<TypeProduct> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
