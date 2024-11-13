using WatchMarketApp.BusinessLogic.Dto_s;
using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.BusinessLogic.Services
{
    public class CommentService : ICommentService
    {
        private IBaseRepository<Comment> _commentRepository;
        public CommentService(IBaseRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> CreateAsync(CommentDto commentDto)
        {
            var newComment = new Comment
            {
                UserId = commentDto.UserId,
                WatchId = commentDto.WatchId,
                Content = commentDto.Content,
                DateTime = commentDto.DateTime,
            };

            await _commentRepository.AddAsync(newComment);

            return new CommentDto
            {
                UserId = commentDto.UserId,
                WatchId = commentDto.WatchId,
                Content = commentDto.Content,
                DateTime = commentDto.DateTime,
            };
        }

        public async Task DeleteAsync(int id)
        {
            var commentLooked = await _commentRepository.GetByIdAsync(id)
            ?? throw new Exception("This comment does not exist");

            await _commentRepository.DeleteAsync(commentLooked);
        }

        public async Task<List<CommentDto>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();

            var commentDto = comments.Select(comment => new CommentDto
            {
                UserId = comment.UserId,
                WatchId = comment.WatchId,
                Content = comment.Content,
                DateTime = comment.DateTime,
            }).ToList();

            return commentDto;
        }

        public async Task<CommentDto> UpdateAsync(CommentDto commentDto)
        {
            var commentLooked = await _commentRepository.GetByIdAsync(commentDto.Id)
                            ?? throw new Exception("This commentDto does not exist");

            commentLooked.UserId = commentDto.UserId;
            commentLooked.WatchId = commentDto.WatchId;
            commentLooked.Content = commentDto.Content;
            commentLooked.DateTime = commentDto.DateTime;

            var updatedComment = await _commentRepository.UpdateAsync(commentLooked);

            return new CommentDto
            {
                UserId = updatedComment.UserId,
                WatchId = updatedComment.WatchId,
                Content = updatedComment.Content,
                DateTime = updatedComment.DateTime,
            };
        }
    }
}
