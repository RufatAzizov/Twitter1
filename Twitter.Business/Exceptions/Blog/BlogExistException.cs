using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Exceptions.Blog
{
    public class BlogExistException : Exception
    {
        public BlogExistException() : base("Blog is already exist")
        {
        }

        public BlogExistException(string? message) : base(message)
        {
        }

    }
}
