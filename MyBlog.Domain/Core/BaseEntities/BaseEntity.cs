using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Core.BaseEntities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreadtedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public Status Status { get; set; }
    }
}
