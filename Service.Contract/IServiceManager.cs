namespace Service.Contract
{
    public interface IServiceManager
    {
        IUserService UserServiec { get; }
        ITypeService TypeService { get; }
        IProductService ProductService { get; }
        ICommentService CommentService { get; }
        IBasketService BacketService { get; }
    }
}
