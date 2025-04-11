namespace Service.Contract
{
    public interface IServiceManager
    {
        IUserService UserServiec { get; }
        ICategoryService CategoryService { get; }
        IProductService ProductService { get; }
        ICommentService CommentService { get; }
        IBasketService BacketService { get; }
    }
}
