using DeptorADO.NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Numerics;

namespace DeptorADO.NET.Configurations;

public class DeptorConfiguration : IEntityTypeConfiguration<Deptor>
{
    public void Configure(EntityTypeBuilder<Deptor> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(b => b.Id).UseIdentityColumn();
    }


    
}
