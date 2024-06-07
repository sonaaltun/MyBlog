using MyBlog.Domain.Core.BaseEntityConfigurations;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;

namespace MyBlog.Infrastructure.Configurations
{
    public class AuthorConfiguration: BaseUserConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);
        }
    }
}
