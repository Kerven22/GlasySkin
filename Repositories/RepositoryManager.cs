using Repositories.DataBaseContext;
using Repository.Contract;
using Repository.Contract.Abstractions;

namespace Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IBasketRepository> _basketRepository; 


        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_repositoryContext));

            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_repositoryContext));

            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(_repositoryContext));

            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_repositoryContext));

            _basketRepository = new Lazy<IBasketRepository>(() => new BaseketRepository(_repositoryContext)); 
        }


        public ICategoryRepository Category => _categoryRepository.Value;

        public IProductRepository Product => _productRepository.Value;

        public ICommentRepository Comment => _commentRepository.Value;

        public IUserRepository User => _userRepository.Value;

        public IBasketRepository Basket => _basketRepository.Value;


        public async Task SaveAsync()=> await _repositoryContext.SaveChangesAsync(); 
    }
}
