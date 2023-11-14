using Application.gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.usecase.product
{
    public class UploadImage
    {
        private readonly SaveImage _imageService;

        public UploadImage(SaveImage imageService)
        {
            _imageService = imageService;
        }

        public string Execute(string fileName, string imageBase64)
        {

           var uniqueName = Guid.NewGuid().ToString() + "-" + fileName;

            var data = new Regex(@"^data:image\/[a-z]+base64,").Replace(imageBase64, "");

            byte[] imageBytes = Convert.FromBase64String(imageBase64);
            
            var path = _imageService.Save(imageBytes, uniqueName);

            return path;

        }
    }
}
