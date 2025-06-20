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
    public class AccessPermissionEntityTypeConfiguration : IEntityTypeConfiguration<AccessPermission>
    {
        public void Configure(EntityTypeBuilder<AccessPermission> builder)
        {
            builder
                .ToTable("AccessPermissions");

            builder
                .HasKey("PermissionId", "AccessId");

            builder
                .HasOne(e => e.Type)
                .WithMany()
                .HasForeignKey(e => e.TypeId);
        }
    }
}
