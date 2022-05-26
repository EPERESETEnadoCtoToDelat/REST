using Eldorado.Domain;
using System;
using System.Collections.Generic;

namespace Eldorado.Persistence.Tests.Infrastructure.Helpers
{
    public static class CategoryHelper
    {
        public static ProductCategory GetOne()
        {
            return new ProductCategory
            {
                Name = "Phones"
            };
        }

        public static IEnumerable<ProductCategory> GetMany()
        {
            yield return GetOne();
        }
    }
}
