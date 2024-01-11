using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.DAL.Configurations
{
    public class TopicsConfigurations : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(t => t.Name).IsRequired()
                .HasMaxLength(32);
            builder.Property(t => t.CreatedTime).IsRequired()
                .HasDefaultValue(DateTime.Now);
        }
    }
}
