using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(product => product.Id);
        builder.Property(product => product.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(product => product.Title).IsUnique();
        builder.Property(product => product.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(product => product.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);

        builder.Property(product => product.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(product => product.Category);
        builder.Property(product => product.Category)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(product => product.ImageUrl);

        builder.Property(product => product.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(product => product.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}
