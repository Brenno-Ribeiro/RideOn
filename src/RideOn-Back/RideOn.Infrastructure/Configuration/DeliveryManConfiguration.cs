using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideOn.Domain.Entities;


namespace RideOn.Infrastructure.Configuration;

internal class DeliveryManConfiguration : IEntityTypeConfiguration<DeliveryMan>
{
    public void Configure(EntityTypeBuilder<DeliveryMan> builder)
    {
        builder.ToTable("delivery_men");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("id").IsRequired();
        builder.Property(d => d.Name).HasMaxLength(150).HasColumnName("name").IsRequired();
        builder.Property(d => d.BirthDate).IsRequired().HasColumnName("birth_date");

        builder.Property(d => d.Created_At).IsRequired().HasColumnName("created_at");
        builder.Property(d => d.Updated_At).IsRequired().HasColumnName("updated_at");

        builder.Property(d => d.Updated_by).IsRequired().HasColumnName("updated_by");
        builder.Property(d => d.Created_by).IsRequired().HasColumnName("created_by");

        builder.OwnsOne(e => e.CNPJ, cnpj =>
        {
            cnpj.Property(c => c.Cnpj).HasMaxLength(14).HasColumnName("cnpj").IsRequired();

            cnpj.HasIndex(c => c.Cnpj)
                .IsUnique()
                .HasDatabaseName("IX_DeliveryMen_CNPJ");
        });

        builder.OwnsOne(e => e.CNH, cnh =>
        {
            cnh.Property(c => c.CnhNumber).HasMaxLength(20).HasColumnName("cnh_number").IsRequired();
            cnh.Property(c => c.CnhType).HasMaxLength(3).HasColumnName("cnh_type").IsRequired();
            cnh.Property(c => c.CnhImage).HasMaxLength(255).HasColumnName("cnh_image").IsRequired();
        });


    }
}
