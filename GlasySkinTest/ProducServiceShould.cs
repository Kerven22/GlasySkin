using FluentAssertions;
using Moq;
using Moq.Language.Flow;
using Repository.Contract.Abstractions;
using Services.ProductService;
using Shared.CreateDtos;
using Shared.Exceptions;

namespace GlasySkinTest
{
    public class ProducServiceShould
    {
        private readonly Mock<IRepositoryManager> repositoryManager;
        private readonly ISetup<IRepositoryManager, Task<bool>> typeExistsSetup;
        private readonly ISetup<IRepositoryManager, Task<ProductDto>> createProductSetup;
        private readonly ProductService sut;
        public ProducServiceShould()
        {
            repositoryManager = new Mock<IRepositoryManager>();

            typeExistsSetup = repositoryManager.Setup(s => s.Product.TypeExists(It.IsAny<Guid>()));

            createProductSetup = repositoryManager.Setup(s => 
                s.Product.CreateProduct(It.IsAny<Guid>(), It.IsAny<string>(),It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<string>()));

            sut = new ProductService(repositoryManager.Object);
        }


        [Fact]
        public async Task ThrowNotFoundException_WhenNoType()
        {
            typeExistsSetup.ReturnsAsync(false); 

            var typeId = Guid.Parse("d49fd654-23cb-403d-9ac4-266fb6503483");

            await sut.Invoking(s => s.Create(typeId, "Clear", 23.4m, 10, "hello",false))
                .Should().ThrowAsync<TypeNotFoundException>();

            repositoryManager.Verify(s => s.Product.TypeExists(typeId)); 
        }

        
        
        [Fact]
        public async Task NewlyCretedProduct_WhenMatchingTypeExists()
        {
            typeExistsSetup.ReturnsAsync(true);
            
            var typeId = Guid.Parse("98e79b97-f11b-4d20-8f8f-c13af487536a"); 
            
            var expected = new ProductDto(typeId, "Clear", 23.4m, 10, "hello");

            createProductSetup.ReturnsAsync(expected); 
            
            var actual  = await sut.Create(typeId, "Clear", 23.4m,  10, "hello",false);
            actual.Should().Be(expected); 
            
            repositoryManager.Verify(s=>s.Product.CreateProduct(typeId, "Clear", 23.4m,10, "hello"));
        }
    }
}