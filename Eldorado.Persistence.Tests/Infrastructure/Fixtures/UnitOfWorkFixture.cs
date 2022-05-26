using Calabonga.UnitOfWork;
using Eldorado.Persistence.Tests.Infrastructure.Helpers;

namespace Eldorado.Persistence.Tests.Infrastructure.Fixtures
{
    public class UnitOfWorkFixture
    {
        public IUnitOfWork<ApplicationDbContext> Create()
        {
            var mock = UnitOfWorkHelper.GetMock();
            return mock.Object;
        }
    }
}
