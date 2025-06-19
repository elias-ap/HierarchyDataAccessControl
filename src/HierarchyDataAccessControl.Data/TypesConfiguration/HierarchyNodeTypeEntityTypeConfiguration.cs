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
    public class HierarchyNodeTypeEntityTypeConfiguration : IEntityTypeConfiguration<HierarchyNodeType>
    {
        public void Configure(EntityTypeBuilder<HierarchyNodeType> builder)
        {
            builder
                .ToTable("HierarchyNodeType");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
