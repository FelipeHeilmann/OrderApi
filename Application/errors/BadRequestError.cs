using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.errors
{
    public class BadRequestError : BaseError
    {
        BadRequestError(string message) : base(message, 422) { }
    }
}
