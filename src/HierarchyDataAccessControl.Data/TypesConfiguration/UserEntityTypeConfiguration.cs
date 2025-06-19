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
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .IsRequired();

            builder
                .HasMany(e => e.Groups)
                .WithMany()
                .UsingEntity<UserAccessGroup>(
                (uag) =>
                {
                    uag
                    .ToTable("UserAccessGroup");

                    uag
                    .HasKey(nameof(UserAccessGroup.UserId), nameof(UserAccessGroup.AccessGroupId));

                    uag
                    .Property(e => e.UserId);

                    uag
                    .Property(e => e.AccessGroupId);

                    uag
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.UserId);

                    uag
                    .HasOne<AccessGroup>()
                    .WithMany()
                    .HasForeignKey(e => e.AccessGroupId);
                }
                );
        }
    }
}
