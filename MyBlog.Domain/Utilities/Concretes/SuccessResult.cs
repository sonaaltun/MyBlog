using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Utilities.Concretes
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true) { }

        public SuccessResult(string messages) : base(true, messages) { }
    }
}
