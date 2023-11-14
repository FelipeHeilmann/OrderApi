using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.errors
{
    public class NotFoundError : BaseError {
        public NotFoundError(string message) : base(message, 404) { }
    }
}
