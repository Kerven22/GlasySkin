namespace Shared.Exceptions
{
    public class CategoryNotFoundException:Exception
    {
        public CategoryNotFoundException(Guid typeId) 
            : base($"Type with id: {typeId} was not found!") { }
    }
}
