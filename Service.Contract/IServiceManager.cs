namespace Service.Contract
{
    public interface IServiceManager
    {
        IUserServie UserServiec { get; }
        ITypeService TypeService { get; }
        IProductService ProductService { get; }
        ICommentService CommentService { get; }
        IBasketService BacketService { get; }
    }
}
