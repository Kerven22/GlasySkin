using FluentAssertions;
using FluentValidation;
using Services.ProductService;
using Shared.CreateDtos;

namespace GlasySkinTest
{
    public class CreateProductCommandValidatorShould
    {
        private readonly CreateProductCommandValidator sut;

        public CreateProductCommandValidatorShould()
        {
            sut = new CreateProductCommandValidator();
        }

        [Fact]
        public void ReturnSuccess_WhenProductCommandIsValid()
        {
            var actual = sut.Validate(new ProductRequestDto( Name:"Gentle Cleanser", Cost:32m, Quantity:5, Review:"Good" ));

            actual.IsValid.Should().BeTrue(); 
        }

        public static IEnumerable<object[]> GetInvlidProductCommdand()
        {
            var product = new ProductRequestDto(Name: "Gentle Cleanser", Cost: 32m, Quantity: 5, Review: "Good");
                yield return new object[] { product with { Name = ""} }; 
                yield return new object[] { product with { Cost = -3 } }; 
                yield return new object[] { product with { Quantity = 0 } }; 
        }

        [Theory]
        [MemberData(nameof(GetInvlidProductCommdand))]
        public void ReturnFailer_WhenProductCommand_IsInvalid(ProductRequestDto productCommand)
        {
            var actual = sut.Validate(productCommand);
            actual.IsValid.Should().BeFalse(); 
        }
    }
}
