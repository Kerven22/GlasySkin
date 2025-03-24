using Service.Contract;

namespace Services
{
    internal sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserServie> _userServie;

        private readonly Lazy<ITypeService> _typeService;



        public IUserServie UserServiec => throw new NotImplementedException();

        public ITypeService TypeService => throw new NotImplementedException();

        public IProductService ProductService => throw new NotImplementedException();

        public ICommentService CommentService => throw new NotImplementedException();

        public IBasketService BacketService => throw new NotImplementedException();
    }
}
