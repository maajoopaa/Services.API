using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Exceptions
{
    public class DataException : ExceptionWithStatusCode
    {
        public DataException(string message, int statusCode)
            : base(message, statusCode) { }
    }
}
