namespace Repository.Contract.Abstractions
{
    public interface IRepositoryManager
    {
        ITypeRepository Type { get; }
        IProductRepository Product { get;  }
        ICommentRepository Comment { get; }
        IUserRepository User { get; }
        IBasketRepository Basket { get; }

        Task SaveAsync(); 
    }
}
