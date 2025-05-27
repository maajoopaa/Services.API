using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Exceptions
{
    public class ConflictException : ExceptionWithStatusCode
    {
        public ConflictException(string message, int statusCode)
            : base(message,statusCode) { }
    }
}
