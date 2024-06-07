using MyBlog.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Utilities.Concretes
{
    public class SuccessDataResult<T> : DataResult<T> where T : class
    {
        public SuccessDataResult() : base(default, true) { }
        public SuccessDataResult(string messages) : base(default, true, messages) { }
        public SuccessDataResult(T data, string messages) : base(data, true, messages) { }
    }
}
