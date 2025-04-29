using Repository.Contract.Abstractions;
using Service.Contract;

namespace Services.CommentService
{
    internal sealed class CommentService(IRepositoryManager _repositoryManager) : ICommentService
    {
    }
}
