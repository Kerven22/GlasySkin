using Repository.Contract.Abstractions;
using Service.Contract;

namespace Services
{
    internal sealed class CommentService(IRepositoryManager _repositoryManager) : ICommentService
    {
    }
}
