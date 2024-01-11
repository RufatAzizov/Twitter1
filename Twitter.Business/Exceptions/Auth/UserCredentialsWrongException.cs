using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.Exceptions.Auth
{
    public class UserCredentialsWrongException : Exception
    {
        public UserCredentialsWrongException() { }
        public UserCredentialsWrongException(string?  message) : base(message) { }
    }
}
