using Entity.Models;
using Repositories.DataBaseContext;
using Repository.Contract;

namespace Repositories
{
    public class CommentRepository(RepositoryContext repositoryContext) : RepositoryBase<Comment>, ICommentRepository
    {
    }
}
