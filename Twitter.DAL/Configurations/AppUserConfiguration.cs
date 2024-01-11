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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.Surname).IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.BirthDay).IsRequired()
                .HasDefaultValue(DateTime.Now);
        }
    }
}
