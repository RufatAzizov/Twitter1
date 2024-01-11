﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations
{
    public class FilesConfiguration : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> modelBuilder)
        {
            modelBuilder.HasOne(f => f.Blog)
                .WithMany(b => b.Files)
                .HasForeignKey(f => f.BlogId);
            modelBuilder.Property(f => f.Name).IsRequired()
                .HasMaxLength(50);
            modelBuilder.Property(f => f.ContentType).IsRequired()
                .HasMaxLength(20);
        }
    }
}
