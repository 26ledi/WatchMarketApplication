using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;

namespace WatchMarketApp.BusinessLogic.Services
{
    public class MediaService : IMediaService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobContainerClient _blobContainerClient;

        public MediaService(IConfiguration configuration, BlobServiceClient blobService)
        {
            _configuration = configuration;
            blobService.GetBlobContainerClient(_configuration["AzureBlobStorage:ContainerName"])
              .CreateIfNotExists();
            _blobContainerClient = blobService.GetBlobContainerClient(_configuration["AzureBlobStorage:ContainerName"]);
        }
        public async Task<BlobDto> GetImageByUrlAsync(string blobName)
        {
            var blobClient = _blobContainerClient.GetBlobClient(blobName);

            if (!await blobClient.ExistsAsync())
            {
                throw new Exception("File not found");
            }

            try
            {
                var downloadInfo = await blobClient.DownloadAsync();
                var contentType = downloadInfo.Value.Details.ContentType;
                var extension = contentType[(contentType.IndexOf("/") + 1)..];

                return new BlobDto
                {
                    Content = downloadInfo.Value.Content,
                    ContentType = downloadInfo.Value.Details.ContentType
                };
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == "BlobNotFound")
            {
                throw new Exception("File not found");
            }
        }
        public async Task UploadOrUpdateDocumentByUrlAsync(string url, IFormFile file)
        {
            try
            {
                var blobClient = _blobContainerClient.GetBlobClient(url);

                await blobClient.UploadAsync(file.OpenReadStream(), new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = file.ContentType
                    }
                });
            }
            catch (RequestFailedException)
            {
                throw;
            }
        }
    }
}
