using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Exceptions
{
    public class NotFoundException : ExceptionWithStatusCode
    {
        public NotFoundException(string message, int statusCode)
            : base(message, statusCode) { }
    }
}
