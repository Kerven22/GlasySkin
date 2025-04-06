using Repository.Contract.Abstractions;
using Service.Contract;
using Services.AuthenticationService;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;

        private readonly Lazy<ITypeService> _typeService;

        private readonly Lazy<IProductService> _productService;

        private readonly Lazy<ICommentService> _commentService;

        private readonly Lazy<IBasketService> _basketService;

        private readonly IJwtProvider _jwtProvider; 

        public ServiceManager(IRepositoryManager repositoryManager, IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider; 
            _userService = new Lazy<IUserService>(() => new UserService.UserService(repositoryManager, _jwtProvider));
            _typeService = new Lazy<ITypeService>(() => new TypeService(repositoryManager));
            _productService = new Lazy<IProductService>(() => new ProductService.ProductService(repositoryManager));
            _commentService = new Lazy<ICommentService>(() => new CommentService(repositoryManager));
            _basketService = new Lazy<IBasketService>(() => new BasketService(repositoryManager));
        }


        public IUserService UserServiec => _userService.Value;

        public ITypeService TypeService => _typeService.Value;

        public IProductService ProductService => _productService.Value;

        public ICommentService CommentService => _commentService.Value;

        public IBasketService BacketService => _basketService.Value; 
    }
}
