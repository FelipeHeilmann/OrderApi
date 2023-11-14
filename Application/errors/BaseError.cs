using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.errors
{
    public class BaseError : Exception
    {
        public readonly int StatusCode;
        public BaseError(string message, int status ): base(message) {
            StatusCode = status;
        }
    }
}
