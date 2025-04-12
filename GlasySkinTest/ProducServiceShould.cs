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
        private readonly ISetup<IRepositoryManager, Task<bool>> categoryExistsSetup;
        private readonly ISetup<IRepositoryManager, Task> createProductSetup;
        private readonly ProductService sut;
        public ProducServiceShould()
        {
            repositoryManager = new Mock<IRepositoryManager>();

            categoryExistsSetup = repositoryManager.Setup(s => s.Category.CategoryExists(It.IsAny<Guid>(),It.IsAny<CancellationToken>()));

            createProductSetup = repositoryManager.Setup(s => 
                s.Product.CreateProduct(It.IsAny<Guid>(), It.IsAny<ProductRequestDto>(), It.IsAny<bool>()));

            sut = new ProductService(repositoryManager.Object);
        }


        [Fact]
        public async Task ThrowNotFoundException_WhenNoType()
        {
            categoryExistsSetup.ReturnsAsync(false); 

            var typeId = Guid.Parse("d49fd654-23cb-403d-9ac4-266fb6503483");

            await sut.Invoking(s => s.Create(typeId, new ProductRequestDto("Clear", 23.4m, 10, "hello"),false, CancellationToken.None))
                .Should().ThrowAsync<CategoryNotFoundException>();

            repositoryManager.Verify(s => s.Category.CategoryExists(typeId, CancellationToken.None)); 
        }

        
        
        [Fact]
        public async Task NewlyCretedProduct_WhenMatchingTypeExists()
        {
            categoryExistsSetup.ReturnsAsync(true);
            
            var typeId = Guid.Parse("98e79b97-f11b-4d20-8f8f-c13af487536a"); 
            
            var expected = new ProductRequestDto("Clear", 23.4m, 10, "hello");

            //createProductSetup.ReturnsAsync(expected); 

            var actual = await sut.Create(typeId, new ProductRequestDto("Clear", 23.4m, 10, "hello"), false, CancellationToken.None);
            actual.Should().Be(expected); 
            
            repositoryManager.Verify(s=>s.Product.CreateProduct(typeId, new ProductRequestDto("Clear", 23.4m,10, "hello"), false));
        }
    }
}