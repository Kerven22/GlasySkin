namespace Shared.Exceptions
{
    public class TypeNotFoundException:Exception
    {
        public TypeNotFoundException(Guid typeId) 
            : base($"Type with id: {typeId} was not found!") { }
    }
}
