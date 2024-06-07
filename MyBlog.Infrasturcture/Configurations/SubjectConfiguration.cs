
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
    public class SubjectConfiguration: AuditableEnitityConfiguration<Subject>
    {
        public override void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(s=>s.Name).IsRequired().HasMaxLength(128);
            base.Configure(builder);
        }
    }
}
