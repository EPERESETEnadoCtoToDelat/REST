using Eldorado.Domain;
using Eldorado.Persistence.Tests.Infrastructure.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eldorado.Persistence.Tests.CustomerTests.CRUD
{
    public class CustomerCRUDTests : IClassFixture<CustomerFixture>
    {
        private readonly CustomerFixture _fixture;

        public CustomerCRUDTests(CustomerFixture fixture)
        {
            _fixture = fixture;
        }

        //[Fact]
        //[Trait(nameof(CustomerCRUDTests), "Customer")]
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
    }
}
