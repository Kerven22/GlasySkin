using Repository.Contract.Abstractions;
using Service.Contract;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserServie> _userService;

        private readonly Lazy<ITypeService> _typeService;

        private readonly Lazy<IProductService> _productService;

        private readonly Lazy<ICommentService> _commentService;

        private readonly Lazy<IBasketService> _basketService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _userService = new Lazy<IUserServie>(() => new UserService(repositoryManager));
            _typeService = new Lazy<ITypeService>(() => new TypeService(repositoryManager));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
            _commentService = new Lazy<ICommentService>(() => new CommentService(repositoryManager));
            _basketService = new Lazy<IBasketService>(() => new BasketService(repositoryManager)); 
        }


        public IUserServie UserServiec => _userService.Value;

        public ITypeService TypeService => _typeService.Value;

        public IProductService ProductService => _productService.Value;

        public ICommentService CommentService => _commentService.Value;

        public IBasketService BacketService => _basketService.Value; 
    }
}
