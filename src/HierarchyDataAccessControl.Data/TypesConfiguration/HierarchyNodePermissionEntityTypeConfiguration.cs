using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyDataAccessControl.Data.TypesConfiguration
{
    public class HierarchyNodePermissionEntityTypeConfiguration : IEntityTypeConfiguration<HierarchyNodePermission>
    {
        public void Configure(EntityTypeBuilder<HierarchyNodePermission> builder)
        {
            builder
                .ToTable("HierarchyNodePermissions");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Value)
                .IsRequired();

            builder
                .HasMany(e => e.Accesess)
                .WithOne()
                .HasForeignKey(e => e.PermissionId);
        }
    }
}
