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
    public class HierarchyNodeEntityTypeConfiguration : IEntityTypeConfiguration<HierarchyNode>
    {
        public void Configure(EntityTypeBuilder<HierarchyNode> builder)
        {
            builder
                .ToTable("HierarchyNode");

            builder
                .HasKey(e => e.Id);

            builder
                .HasIndex(e => e.Id)
                .IsUnique();

            builder
                .Property(e => e.Id)
                .IsRequired();

            builder
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(e => e.Type)
                .WithMany()
                .HasForeignKey(e => e.TypeId);

            builder.Ignore(e => e.ChildrenNodes);
            builder.Ignore(e => e.Permissions);
            builder.Ignore(e => e.Parent);
        }
    }
}
