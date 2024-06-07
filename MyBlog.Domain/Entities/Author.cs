using MyBlog.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
    public class Author: BaseUser
    {

        // Nav Prop
        public virtual IEnumerable<Article>Articles { get; set; }
    }
}
