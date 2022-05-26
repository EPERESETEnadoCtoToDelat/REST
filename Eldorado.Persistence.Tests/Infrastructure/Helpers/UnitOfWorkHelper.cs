using Calabonga.UnitOfWork;
using Eldorado.Domain;
using Moq;

namespace Eldorado.Persistence.Tests.Infrastructure.Helpers
{
    public static class UnitOfWorkHelper
    {
        public static Mock<IUnitOfWork<ApplicationDbContext>> GetMock()
        {
            var context = new DbContextHelper().Context;
            var unitOfWork = new Mock<IUnitOfWork<ApplicationDbContext>>();

            unitOfWork
                .Setup(x => x.GetRepository<ProductCategory>(false))
                .Returns(new Repository<ProductCategory>(context));

            unitOfWork
                .Setup(x => x.GetRepository<Customer>(false))
                .Returns(new Repository<Customer>(context));

            unitOfWork
                .Setup(x => x.GetRepository<CustomerAddress>(false))
                .Returns(new Repository<CustomerAddress>(context));

            unitOfWork
                .Setup(x => x.GetRepository<CreditCard>(false))
                .Returns(new Repository<CreditCard>(context));

            var scope1 = context.Database.BeginTransaction();
            var scope2 = context.Database.BeginTransactionAsync();

            unitOfWork.Setup(x => x.BeginTransaction(false)).Returns(scope1);
            unitOfWork.Setup(x => x.BeginTransactionAsync(false)).Returns(scope2);
            unitOfWork.Setup(x => x.LastSaveChangesResult).Returns(new SaveChangesResult());

            return unitOfWork;
        }
    }
}
