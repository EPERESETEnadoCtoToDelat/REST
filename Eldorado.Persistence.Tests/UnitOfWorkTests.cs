using Calabonga.UnitOfWork;
using Eldorado.Domain;
using Eldorado.Persistence.Tests.Infrastructure.Fixtures;
using System.Linq;
using Xunit;

namespace Eldorado.Persistence.Tests
{
    public class UnitOfWorkTests : IClassFixture<UnitOfWorkFixture>
    {
        private readonly UnitOfWorkFixture _fixture;

        public UnitOfWorkTests(UnitOfWorkFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [Trait(nameof(UnitOfWorkTests), "InstanceCreated")]
        public void ItShould_UnitOfWork_Instance_Created()
        {
            //arrange
            var sut = _fixture.Create();

            //act

            //assert
            Assert.NotNull(sut);
        }

        [Fact]
        [Trait(nameof(UnitOfWorkTests), nameof(ProductCategory))]
        public void ItShould_Contains_ProductCategory_1()
        {
            //arrange
            const int expected = 1;
            var sut = _fixture.Create();

            //act
            var actual = sut.GetRepository<ProductCategory>().Count();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait(nameof(UnitOfWorkTests), nameof(ProductCategory))]
        public void ItShould_Contains_ProductCategory_With_Special_Name()
        {
            //arrange
            const string expected = "Phones";
            var sut = _fixture.Create();

            //act
            var actual = sut.GetRepository<ProductCategory>().GetFirstOrDefault()?.Name;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait(nameof(UnitOfWorkTests), "Customer")]
        public void ItShould_Contain_Customer_1()
        {
            //arrange
            const int expected = 1;
            var sut = _fixture.Create();

            //act
            var actual = sut.GetRepository<Customer>().GetAll(false).Count();

            //assert
            Assert.Equal(expected, actual);
        }

        //[Fact]
        //[Trait(nameof(UnitOfWorkTests), "Customer")]
        //public void ItShould_CreditCard_In_Customer_1()
        //{
        //    //arrange
        //    var sut = _fixture.Create();

        //    //act
        //    var customer = sut
        //        .GetRepository<Customer>()
        //        .GetFirstOrDefault(include: i => i.Include);
        //    //var card = 

        //    //assert
        //    Assert.Equal(expected, actual);
        //}
    }
}
