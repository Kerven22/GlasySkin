using AutoMapper;
using Repository.Contract.Abstractions;
using Service.Contract;
using Services.AuthenticationService;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;

        private readonly Lazy<ICategoryService> _categoryService;

        private readonly Lazy<IProductService> _productService;

        private readonly Lazy<ICommentService> _commentService;

        private readonly Lazy<IBasketService> _basketService;

        private readonly IJwtProvider _jwtProvider; 

        public ServiceManager(IRepositoryManager repositoryManager, IJwtProvider jwtProvider, IMapper mapper)
        {
            _jwtProvider = jwtProvider; 
            _userService = new Lazy<IUserService>(() => new UserService.UserService(repositoryManager, _jwtProvider));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService.CategoryService(repositoryManager, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService.ProductService(repositoryManager));
            _commentService = new Lazy<ICommentService>(() => new CommentService.CommentService(repositoryManager));
            _basketService = new Lazy<IBasketService>(() => new BasketService.BasketService(repositoryManager));
        }


        public IUserService UserServiec => _userService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

        public IProductService ProductService => _productService.Value;

        public ICommentService CommentService => _commentService.Value;

        public IBasketService BacketService => _basketService.Value; 
    }
}
