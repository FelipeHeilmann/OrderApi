using Application.gateway;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.gateway
{
    public class AzureSaveImage : SaveImage
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureSaveImage(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public string Save(byte[] imageBytes, string fileName)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient("products");

            var blobInstance = containerInstance.GetBlobClient(fileName);

            using (var stream = new MemoryStream(imageBytes)) 
            {
                blobInstance.Upload(stream);
            }

            return blobInstance.Uri.AbsoluteUri;
        }
    }
}
