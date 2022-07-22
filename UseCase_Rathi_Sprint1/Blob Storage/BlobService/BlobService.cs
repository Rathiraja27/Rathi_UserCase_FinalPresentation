using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Tsp;
using SixLabors.ImageSharp.Formats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Blob_Storage.BlobService
{
    public class BlobService
    {
        private readonly CloudBlobContainer _cloudBlobContainer;
        private static string AzureBlobStorageConnectionString { get; set; }
        private static string CloudBlobContainerName { get; set; }
        public static IConfiguration _configuration { get; private set; }

        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            CloudBlobContainerName = _configuration["Azure:Storage:CloudBlobContainerName"];
            AzureBlobStorageConnectionString = _configuration["Azure:Storage:ConnectionString"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(AzureBlobStorageConnectionString);
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            _cloudBlobContainer = cloudBlobClient.GetContainerReference(CloudBlobContainerName);

        }

        public async Task<string> Upload(IFormFile blob)
        {
            string url = "";
            byte[] blobBytes;

            if (blob.Length > 0)
            {
                var fileName = GetFileName(blob);

                var blobName = GenerateImageName(fileName);

                blobBytes = ConvertImageToByteArray(blob);

                var blobUrl = await UploadImageByteArray(
                    blobBytes,
                    blobName,
                    blob.ContentType);

                url = blobUrl;

            }
            return url;
        }

        private async Task<string> UploadImageByteArray(
           byte[] imageBytes,
           string imageName,
           string contentType)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                return null;
            }

            var cloudBlockBlob = _cloudBlobContainer.GetBlockBlobReference(imageName);

            cloudBlockBlob.Properties.ContentType = contentType;

            const int byteArrayStartIndex = 0;

            await cloudBlockBlob.UploadFromByteArrayAsync(
                imageBytes,
                byteArrayStartIndex,
                imageBytes.Length);

            var imageFullUrlPath = cloudBlockBlob.Uri.ToString();

            return imageFullUrlPath;
        }


        private byte[] ConvertImageToByteArray(IFormFile image)
        {
            byte[] result = null;

            using (var fileStream = image.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                result = memoryStream.ToArray();
            }

            return result;
        }

        private string GetFileName(IFormFile image)
        {
            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition)
                        .FileName.Trim().ToString();

            return fileName;
        }

        private string GenerateImageName(string fileName)
        {
            var imageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(fileName)}";

            return imageName;
        }


        public string UploadPdf(byte[] pdf, string fileName)
        {
            string url = string.Empty;
            try
            {
                var blobUrl = UploadImageByteArray(
                        pdf,
                        fileName,
                        "application/pdf");

                url = blobUrl.Result;
            }
            catch (Exception ex)
            {

            }

            return url;
        }
        


    }
}
