
using MyBlog.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
    public class Article: AuditableEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public byte[]? Image { get; set; }
        public int ViewCount { get; set; }
        public TimeSpan ReadTime { get; set; }

        // Nav Prop
        public Guid AuthorId { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Author Author{ get; set; }

        public virtual Subject Subject { get; set; }
    }
}
