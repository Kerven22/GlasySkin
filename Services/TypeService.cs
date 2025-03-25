using Repository.Contract.Abstractions;
using Service.Contract;
using Shared.ResponsiesDto;

namespace Services
{
    internal sealed class TypeService(IRepositoryManager _repositoryManager) : ITypeService
    {
        public async Task<IEnumerable<TypeResponseDto>> GetAllProductTypes(bool trackChanges)
        {
            var typesEntity = await _repositoryManager.Type.GetTypesAsync(trackChanges);

            var typesResponseDto = typesEntity.Select(s => new TypeResponseDto(s.TypeId, s.Name));

            return typesResponseDto; 
        }
    }
}
