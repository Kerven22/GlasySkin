using FluentAssertions;
using Services.ProductService;

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
            var actual = sut.Validate(new CreateProductCommand() 
            { TypeId = Guid.Parse("3c11854e-a340-413d-8873-5565506dc343"), 
                Name = "Gentle Cleanser", 
                Cost = 32m,
                Quantity = 5, 
                Review = "Good" });

            actual.IsValid.Should().BeTrue(); 
        }

        public static IEnumerable<object[]> GetInvlidProductCommdand()
        {
            yield return new[] { new CreateProductCommand() { TypeId = Guid.Empty, Name = "CreateProductCommand", Cost = 23, Quantity = 10, Review = "Good" } }; 
        }

        [Theory]
        [MemberData(nameof(GetInvlidProductCommdand))]
        public void ReturnFailer_WhenProductCommand_IsInvalid(CreateProductCommand productCommand)
        {
            var actual = sut.Validate(productCommand);
            actual.IsValid.Should().BeFalse(); 
        }
    }
}
