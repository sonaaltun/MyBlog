﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Utilities.Concretes
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false) { }

        public ErrorResult(string messages) : base(false, messages) { }
    }
}
