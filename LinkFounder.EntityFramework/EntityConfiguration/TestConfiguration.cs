﻿using LinkFounder.DbSaver.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LinkFounder.DbSaver.EntityConfiguration
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Property(p => p.TimeCreated)
                .HasComputedColumnSql("CONVERT(date,GETUTCDATE())");
        }
    }
}
