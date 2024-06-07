using MyBlog.Domain.Core.BaseEntities;

namespace MyBlog.Domain.Entities
{
    public class Subject: AuditableEntity
    {
        public string Name { get; set; }


        // Nav Prop
        public virtual IEnumerable<Article> Articles { get; set; }
    }
}
