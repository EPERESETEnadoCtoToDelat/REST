using Calabonga.UnitOfWork;
using Eldorado.Persistence.Tests.Infrastructure.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Persistence.Tests.Infrastructure.Fixtures
{
    public class CustomerFixture
    {
        public IUnitOfWork<ApplicationDbContext> Create()
        {
            var mock = UnitOfWorkHelper.GetMock();
            return mock.Object;
        }
    }
}
