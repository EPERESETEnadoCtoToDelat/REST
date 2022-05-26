using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Persistence.Tests.Infrastructure.Helpers
{
    public class DbContextHelper
    {
        public ApplicationDbContext Context { get; set; }

        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase("ELDORADO_DB_UNIT_TESTINGS")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;

            Context = new ApplicationDbContext(options);

            Context.Database.EnsureDeleted();
            //Context.Database.EnsureCreated();

            Context.AddRange(CategoryHelper.GetMany());
            Context.AddRange(CustomerHelper.GetMany());
            

            Context.SaveChanges();
        }

        //public static void Destroy(ApplicationDbContext context)
        //{
        //    context.Database.EnsureDeleted();
        //    context.Dispose();
        //}
    }
}
