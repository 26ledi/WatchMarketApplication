using Microsoft.AspNetCore.Http;
using WatchMarketApp.BusinessLogic.Dto_s;

namespace WatchMarketApp.BusinessLogic.Interfaces
{
    public interface IMediaService
    {
        Task<BlobDto> GetImageByUrlAsync(string blobName);
        Task UploadOrUpdateDocumentByUrlAsync(string url, IFormFile file);
    }
}
