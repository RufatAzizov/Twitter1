using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.DAL.Configurations
{
    public class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(512);
            builder.HasOne(e => AppUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.ParentComment)
               .WithMany(e => e.Children)
               .HasForeignKey(e => e.ParentCommentId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Blog)
                .WithMany(u => u.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
