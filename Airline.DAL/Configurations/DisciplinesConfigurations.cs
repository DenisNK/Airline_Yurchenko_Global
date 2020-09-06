﻿using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;
namespace Airline.DAL.Configurations
{
    public class DisciplinesConfigurations : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(TABLE_DISCIPLINES);

            builder.HasOne(p => p.Teacher)
                .WithMany(t => t.Discipline)
                .HasForeignKey(p => p.TeacherId);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.Annotation)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
