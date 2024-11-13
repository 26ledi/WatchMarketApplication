using WatchMarketApp.BusinessLogic.Dto_s;

namespace WatchMarketApp.BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDto> CreateAsync(CommentDto commentDto);
        Task<CommentDto> UpdateAsync(CommentDto commentDto);
        Task DeleteAsync(int id);
        Task<List<CommentDto>> GetAllAsync();
    }
}
