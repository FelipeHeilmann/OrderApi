using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.gateway
{
    public interface SaveImage
    {
        public string Save(byte[] imageBytes, string fileName);
    }
}
