
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Core.BaseEntityConfigurations;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Configurations
{
    public class ArticleConfiguration: AuditableEnitityConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a=>a.Title).IsRequired().HasMaxLength(128);
            builder.Property(a=>a.Content).IsRequired();
            builder.Property(a=>a.Image).IsRequired(false);          

            base.Configure(builder);
        }
    }
}
